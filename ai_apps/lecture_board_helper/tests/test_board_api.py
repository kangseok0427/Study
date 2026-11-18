import base64
import io
import json
from pathlib import Path
import sys
from types import SimpleNamespace
import wave

from fastapi.testclient import TestClient
from PIL import Image
import pytest

sys.path.insert(0, str(Path(__file__).resolve().parents[1] / "backend"))
import board_api as api


@pytest.fixture
def client(monkeypatch):
    monkeypatch.setenv("APP_ACCESS_CODE", "local-test-only")
    return TestClient(api.app)


def photo():
    out = io.BytesIO()
    Image.new("RGB", (12, 12), "white").save(out, "PNG")
    return base64.b64encode(out.getvalue()).decode()


def sound(seconds=1):
    out = io.BytesIO()
    with wave.open(out, "wb") as audio:
        audio.setnchannels(1)
        audio.setsampwidth(2)
        audio.setframerate(8000)
        audio.writeframes(b"\0\0" * 8000 * seconds)
    return base64.b64encode(out.getvalue()).decode()


def deny_model(monkeypatch):
    def fail():
        pytest.fail("Invalid request reached the model")
    monkeypatch.setattr(api, "get_client", fail)


def test_rejects_wrong_access_before_model(client, monkeypatch):
    deny_model(monkeypatch)
    response = client.post("/analyze", json={"image_b64": photo(), "question": "정리해줘"}, headers={"X-Access-Code": "wrong"})
    assert response.status_code == 401


def test_unconfigured_access_fails_closed(client, monkeypatch):
    monkeypatch.delenv("APP_ACCESS_CODE")
    deny_model(monkeypatch)
    assert client.post("/analyze", json={"image_b64": photo(), "question": "정리해줘"}).status_code == 503


@pytest.mark.parametrize("payload,status", [
    ({"image_b64": photo()}, 422),
    ({"image_b64": "아님", "question": "질문"}, 422),
    ({"image_b64": base64.b64encode(b"not an image").decode(), "question": "질문"}, 422),
    ({"image_b64": photo(), "audio_b64": base64.b64encode(b"not wav").decode()}, 422),
    ({"image_b64": photo(), "audio_b64": sound(61)}, 413),
    ({"image_b64": "A" * 3_000_000, "audio_b64": "A" * 1_500_000}, 422),
])
def test_invalid_media_and_single_modality_do_not_call_model(client, monkeypatch, payload, status):
    deny_model(monkeypatch)
    assert client.post("/analyze", json=payload, headers={"X-Access-Code": "local-test-only"}).status_code == status


@pytest.mark.parametrize("question,audio,expected", [
    ("base64만 설명해줘", None, ["사진", "텍스트"]),
    ("", sound(), ["사진", "음성"]),
    ("쉽게 설명해줘", sound(), ["사진", "텍스트", "음성"]),
])
def test_question_modalities_reach_one_model_request(client, monkeypatch, question, audio, expected):
    calls = []
    result = {key: "검증용 정리" for key in api.FIELDS}
    def create(**kwargs):
        calls.append(kwargs)
        return SimpleNamespace(output_text=json.dumps({"result": result, "heard_question": "음성 질문"}), usage=SimpleNamespace(total_tokens=321))
    monkeypatch.setattr(api, "get_client", lambda: SimpleNamespace(interactions=SimpleNamespace(create=create)))
    payload = {"image_b64": photo(), "question": question}
    if audio:
        payload["audio_b64"] = audio
    response = client.post("/analyze", json=payload, headers={"X-Access-Code": "local-test-only"})
    assert response.status_code == 200
    assert response.json()["used_inputs"] == expected
    assert len(calls) == 1
    parts = calls[0]["input"]
    assert any(part["type"] == "image" for part in parts)
    assert any(part["type"] == "audio" for part in parts) == bool(audio)
    if question:
        assert any(question in part.get("text", "") for part in parts)
    assert calls[0]["store"] is False


def test_bad_model_result_becomes_readable_error(client, monkeypatch):
    create = lambda **kwargs: SimpleNamespace(output_text='{"result": {}}', usage=None)
    monkeypatch.setattr(api, "get_client", lambda: SimpleNamespace(interactions=SimpleNamespace(create=create)))
    assert client.post("/analyze", json={"image_b64": photo(), "question": "질문"}, headers={"X-Access-Code": "local-test-only"}).status_code == 502
