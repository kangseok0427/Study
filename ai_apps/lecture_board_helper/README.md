# 강의 판서 정리 도우미

제출 주제는 강의 판서 정리다. 판서 사진에 텍스트 질문이나 음성 질문을 함께 보내 **주제·핵심 3줄·용어 설명·복습 질문**으로 정리한다. 사진만 보내는 요청은 받지 않는다.

- 사진 + 텍스트 / 사진 + 음성 / 사진 + 텍스트 + 음성을 지원한다. 한 번의 AI 요청에 함께 넣는다.
- 음성은 WAV 녹음이며 1분 이내다. 음성 질문의 해석도 결과 화면에서 확인한다.
- 예시 사진은 코드로 만든 판서이며, 예시 음성은 Windows 한국어 합성 음성이다. 사람의 사진·음성을 사용하지 않았다.
- `backend/main.py`와 `board_api.py`: FastAPI의 `GET /`, `POST /analyze`. 키와 접근 코드는 환경 변수로 읽는다.
- `frontend/board_app.py`: Streamlit 화면. `API_URL`, `APP_ACCESS_CODE`를 Secrets에 설정한다.
- `backend/legacy_api.py`: 앞선 사진·음성 실습의 주소를 유지하는 내부 호환 코드다. 판서 API 문서에는 표시하지 않는다.

Vercel은 앞서 생성한 `photo-voice-helper` 프로젝트의 키 설정을 재사용한다. 판서 전용 URL 별칭을 붙여 배포한다. 화면은 별도 Streamlit 앱을 배포한다. Streamlit의 실행 경로는 `ai_apps/lecture_board_helper/frontend/board_app.py`다.

실제 화면: https://lecture-board-kangseok.streamlit.app / API 문서: https://lecture-board-kangseok.vercel.app/docs / [Colab 재실행 코드](https://colab.research.google.com/drive/1h7eSA3peyis6_h2CzUzvt7_mVnuOWuN5).

실제 배포 화면에서 사진+텍스트의 base64 조건, 사진+합성 음성의 JSON 복습 질문 조건이 각각 반영되는 것을 확인했다. [검증 결과](records/Verification_Results.json)와 [완료 보고서](records/LECTURE-BOARD-20261118_Completion.md)를 참고한다. Colab 파일은 재실행용으로 준비했으며 실행하지 않은 셀의 출력은 비워 뒀다.

로컬 검증: `python -m pip install -r backend/requirements.txt pytest httpx` 후 `python -m pytest -q tests`. 외부 AI는 모의 응답으로 대체한 입력 경계 검사 12개이며, 실제 AI 검증은 별도로 기록한다.

API 형식은 [Gemini Interactions 공식 문서](https://ai.google.dev/api/interactions-api?hl=en), 배포 진입점은 [Vercel FastAPI 공식 문서](https://vercel.com/docs/frameworks/backend/fastapi)를 참고했다. 키·접근 코드를 저장소나 제출 파일에 적지 않는다.
