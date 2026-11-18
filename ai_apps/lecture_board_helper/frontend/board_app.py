import base64
import io
from pathlib import Path

import requests
import streamlit as st
from PIL import Image, ImageOps, UnidentifiedImageError

APP_DIR = Path(__file__).resolve().parent
st.set_page_config(page_title="강의 판서 정리 도우미", page_icon="📚")
st.title("📚 강의 판서 정리 도우미")
st.caption("판서 사진에 텍스트·음성 질문을 더해 주제, 핵심 3줄, 용어 설명, 복습 질문으로 정리해요.")

try:
    API_URL = st.secrets["API_URL"].rstrip("/")
    ACCESS_CODE = st.secrets["APP_ACCESS_CODE"]
except (KeyError, FileNotFoundError):
    st.error("앱 연결 설정이 필요합니다.")
    st.stop()


def show_result(data):
    st.subheader("정리 결과")
    if data.get("heard_question"):
        st.info("음성으로 전달한 질문: " + data["heard_question"])
    for name, content in data["result"].items():
        st.markdown("#### " + name)
        st.write(content)
    st.caption("함께 사용한 입력: " + " · ".join(data["used_inputs"]) + f" · 상태 200 · 토큰 {data.get('tokens')}")


def analyze(photo_raw, question, audio_raw=None):
    try:
        with Image.open(io.BytesIO(photo_raw)) as original:
            image = ImageOps.exif_transpose(original).convert("RGB")
        image.thumbnail((1024, 1024))
        buffer = io.BytesIO()
        image.save(buffer, format="JPEG", quality=85)
        payload = {"image_b64": base64.b64encode(buffer.getvalue()).decode(), "question": question}
        if audio_raw:
            payload["audio_b64"] = base64.b64encode(audio_raw).decode()
        if len(payload["image_b64"]) + len(payload.get("audio_b64", "")) > 4_000_000:
            st.error("파일이 너무 큽니다. 사진을 줄이거나 녹음을 짧게 해 주세요.")
            return
        response = requests.post(API_URL + "/analyze", json=payload,
            headers={"X-Access-Code": ACCESS_CODE}, timeout=130)
        if response.status_code != 200:
            try:
                detail = response.json().get("detail", "요청 실패")
            except ValueError:
                detail = "서버 응답을 읽을 수 없습니다."
            st.error(f"상태 {response.status_code}: {detail}")
            return
        st.session_state["board_result"] = response.json()
    except (UnidentifiedImageError, OSError, Image.DecompressionBombError):
        st.error("사진을 읽을 수 없습니다. 다른 사진을 선택해 주세요.")
    except requests.RequestException:
        st.error("서버에 연결하지 못했습니다. 잠시 뒤 다시 시도해 주세요.")


st.subheader("1. 판서 사진")
camera = st.camera_input("판서 촬영") if st.toggle("카메라로 찍기") else None
upload = st.file_uploader("사진 파일 선택", type=["png", "jpg", "jpeg", "webp"])
photo = camera or upload
if photo:
    st.image(photo, width=420)

st.subheader("2. 질문 추가")
question = st.text_area("텍스트 질문", value="핵심을 쉽게 설명하고 복습 질문 두 개를 만들어 주세요.", height=90)
audio = st.audio_input("음성 질문 녹음 (선택 · 1분 이내)")
st.caption("사진 + 텍스트, 사진 + 음성, 사진 + 텍스트 + 음성을 함께 사용할 수 있어요.")
if st.button("판서 정리하기", type="primary", disabled=photo is None or not (question.strip() or audio)):
    with st.spinner("사진과 질문을 함께 읽고 있어요..."):
        analyze(photo.getvalue(), question, audio.getvalue() if audio else None)

with st.expander("예시로 먼저 해 보기", expanded=True):
    st.caption("코드로 만든 판서와 컴퓨터 합성 음성 예시입니다.")
    left, right = st.columns(2)
    if left.button("예시: 사진 + 텍스트", key="sample_text"):
        st.image(str(APP_DIR / "lecture_board.png"), width=420)
        with st.spinner("판서와 텍스트 질문을 읽고 있어요..."):
            analyze((APP_DIR / "lecture_board.png").read_bytes(), "용어 설명에는 base64만 설명해 주세요.")
    if right.button("예시: 사진 + 음성", key="sample_voice"):
        st.image(str(APP_DIR / "lecture_board.png"), width=420)
        voice = (APP_DIR / "voice_question.wav").read_bytes()
        st.audio(voice, format="audio/wav")
        with st.spinner("판서와 음성 질문을 함께 읽고 있어요..."):
            analyze((APP_DIR / "lecture_board.png").read_bytes(), "", voice)

if "board_result" in st.session_state:
    show_result(st.session_state["board_result"])
