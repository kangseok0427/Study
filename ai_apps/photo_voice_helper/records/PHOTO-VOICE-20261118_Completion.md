# 사진·음성 도우미 실행·배포 기록

태스크: PHOTO-VOICE-20261118 / 요청자: 강석현 / 담당자·실제 수행자: Codex AI

목표는 14주차 실습 6~7의 사진·음성 도우미를 먼저 실행하고 별도 Vercel 프로젝트로 배포하는 것이다. 사진+텍스트 질문과 음성 입력, 정상 응답과 잘못된 요청의 차단, Streamlit 화면 연동을 확인한다.

코랩에서 실습 6-0 접근 코드 설정을 실행한 후 서버를 재시작했다. 기존에 잘못된 코드도 200으로 처리된 기록은 서버에 접근 코드가 적용되지 않은 상태였다. 재실행 후 사진 200(폴리 카페·15,300원), 음성 200, 잘못된 코드 401, 잘못된 base64 422를 확인했다. Streamlit AppTest에서도 정상 코드의 분석 결과와 코드가 없을 때의 401 표시를 직접 확인했다. 앞선 기초 실습의 기존 실행 기록과 이번 AI의 재실행을 구분한다.

버전: Python 3 Colab 런타임, FastAPI 0.141.1, google-genai 2.12.1, Streamlit 1.66.1, requests 2.32.4, Pillow 11.3.0. 로컬에서는 추출한 Python 파일의 문법 검사를 통과했다.

별도 Vercel 프로젝트 `kangseok0427s-projects/photo-voice-helper`를 공식 CLI 66.0.0으로 생성했다. 연결 도구의 생성 요청은 403이었으며, 같은 대상에 대한 CLI 생성은 성공했다. Production 배포의 READY 상태와 https://photo-voice-helper.vercel.app 의 200 응답을 확인했다. 기존 프로젝트는 변경하지 않았다.

화면 https://photo-voice-kangseok.streamlit.app 를 별도로 생성해 동일한 접근 코드로 연결했다. 실제 배포 화면의 예제 사진 버튼은 폴리 카페·합계 15,300원, 상태 200·1194토큰을 표시했다. 예제 음성 버튼은 받아쓰기 결과와 상태 200·300토큰을 표시했다. 음성 결과에서 원문 '오천 원'을 '1,000원', '짰습니다'를 '잡습니다'로 인식한 오차가 있었다. 전송·화면 연동은 성공했지만 받아쓰기 정확성에는 한계가 있다. [사진 캡처](evidence/Photo_Analysis.jpg), [음성 캡처](evidence/Voice_Analysis.jpg), [실행 노트북](PhotoVoiceHelper_Executed_20261118.ipynb)을 근거로 보관한다.

배포된 API의 OpenAPI에서 /, /describe, /listen 세 경로를 확인했고, 잘못된 접근 코드의 실제 요청이 401로 거절되는 것을 확인했다. Production 환경 변수 GEMINI_API_KEY·APP_ACCESS_CODE 등록 후 재배포했다. 최종 백엔드 배포는 `dpl_AoZmKLP4jSJ918yCRku7UrmBZ24D`이며 검증한 코드 커밋은 `793dbf7f367d01320cf6c9271c308819410549e2`다. 배포 폴더와 커밋의 main.py 해시 일치를 확인했다(SHA-256 `DC2537A222934DF1A6DD8E057F7ADA230265DF84824A07E86D2EDA54C439AA0A`). 키·코드는 문서·소스·ZIP에 남기지 않는다.

휴대폰 카메라·마이크의 실제 입력은 미확인으로 남긴다. 브라우저에서 코드로 만든 예제 사진·음성으로 실제 API 연결을 검증한 결과와 구분한다. 휴대폰 확인 담당은 미정이며, 실기기를 사용할 수 있는 사람이 화면 주소에서 카메라 또는 녹음을 사용해 분석하는 확인이 필요하다.

학습·개선: 서버 환경 변수를 바꾼 뒤 재시작·재배포해야 적용된다. 음성 200 응답에서도 기계 발음을 잘못 인식했으므로, 전송 성공과 내용 정확성을 따로 확인해야 한다.

검증: 코랩·Production API·배포 화면 예제 분석 완료 / 휴대폰 검증 대기 / 개인 작업의 회의 공유 해당 없음 / 승인·머지 사용자 검토 대기. [PR #4](https://github.com/kangseok0427/Study/pull/4)를 검토용으로 제출하며 main에는 병합하지 않는다. 사용자는 기능과 인식 오차를 검토할 수 있다.

추가 제출 조건(사용자 제공): 서비스 URL, Streamlit Secrets 화면(값 숨김), API /docs 화면. 이 세 항목만 담은 `20261118_AI_PLF_Submission.zip`을 바탕화면에 준비하고 파일 개수·압축 내용 해시를 확인했다. [Secrets 캡처](evidence/Streamlit_Secrets_Masked.jpg)는 실제 앱 설정 창에서 값을 캡처용 별표로 임시 편집한 미저장 화면이며, 캡처 후 Discard로 버렸다. 저장 버튼을 누르지 않아 실제 설정은 유지된다. [API 문서 캡처](evidence/API_Docs.jpg)는 새 서비스의 /docs 화면이며 GET /, POST /describe, POST /listen을 표시한다. 실제 학습 시스템 업로드는 하지 않았다. 사용자 제공 마감은 2026-11-24 23:59(한국 시간)다.
