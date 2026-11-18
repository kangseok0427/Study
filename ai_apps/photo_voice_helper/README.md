# 사진·음성 도우미

14주차 실습 6~7의 FastAPI 서버와 Streamlit 화면이다. 사진과 텍스트 질문을 보내거나 음성을 보내 받아쓰기·요약·영어 번역을 요청한다.

- `backend/main.py`: `GET /`, `POST /describe`, `POST /listen`. Gemini 키는 서버 환경 변수로만 읽는다.
- `frontend/app.py`: 사진 파일·카메라·텍스트 질문·음성 녹음과 예제 버튼을 제공한다. 사진은 1024px 이하 JPEG로 줄이고, 파일은 base64 JSON으로 서버에 보낸다.
- `frontend/receipt.png`, `voice.wav`: 수업 코드로 만든 영수증과 기계 음성 예제다.
- `records/`: 실행 결과와 작업 기록. 비밀 값은 포함하지 않는다.

백엔드는 `backend/`를 Vercel 프로젝트 루트로 배포하고 Production 환경 변수 `GEMINI_API_KEY`, `APP_ACCESS_CODE`를 등록한다. 화면은 Streamlit Community Cloud에서 이 브랜치의 `ai_apps/photo_voice_helper/frontend/app.py`를 선택한다. 화면 Secrets에는 `API_URL`과 동일한 `APP_ACCESS_CODE`를 넣는다. 예제 설정은 `frontend/secrets.toml.example`에 있다.

실제 API 주소: https://photo-voice-helper.vercel.app

코랩에서 사진·음성 200, 잘못된 코드 401, 잘못된 base64 422와 화면 예제 실행을 확인했다. 기계 음성의 김치찌개를 다른 음식으로 인식한 결과도 있어, 정상 응답이 내용의 정확성을 보장하지는 않는다. 카메라·마이크의 실제 휴대폰 사용은 별도 확인이 필요하다.

원본 교안과의 차이는 화면에서 예제 파일 경로를 `app.py` 기준으로 찾도록 한 점이다. 저장소 하위 폴더에서도 예제 버튼이 표시되게 했다. 판서 정리 과제는 별도 작업이다.
