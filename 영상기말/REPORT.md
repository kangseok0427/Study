# 동전 개수 세기 — 영상인공지능처리 기말 프로젝트

## 1. 문제 정의

| 항목 | 내용 |
|------|------|
| 입력 | 동전 사진 1장 |
| 출력 | 동전 개수 + 번호 표시 이미지 |
| 조건 | 동전끼리 겹치지 않음 |

"동전이 여러 개 놓여있을 때, 카메라로 찍은 사진 한 장으로 자동으로 개수를 셀 수 있을까?"

---

## 2. 전체 처리 흐름

```
입력 이미지
→ 그레이스케일 변환
→ 가우시안 블러 (노이즈 제거)
→ 이진화 Otsu (배경/동전 분리)
→ 모폴로지 연산 (잡티 제거)
→ 외곽선 검출
→ 원형성 계산 + 판별
→ 결과 출력
```

---

## 3. 단계별 설명

### 3-1. 그레이스케일 변환
```python
gray = cv2.cvtColor(img_bgr, cv2.COLOR_BGR2GRAY)
```
색상 정보 제거. 이진화는 밝기 기반이라 컬러 불필요.

### 3-2. 가우시안 블러
```python
blur = cv2.GaussianBlur(gray, (11, 11), 0)
```
카메라 노이즈 제거. 적용 안 하면 잡티가 동전으로 오인됨.

### 3-3. 이진화 (Otsu)
```python
_, binary = cv2.threshold(blur, 0, 255, cv2.THRESH_BINARY_INV + cv2.THRESH_OTSU)
```
임계값 자동 계산. 배경 밝기 평균값으로 이진화 방향 자동 감지.

### 3-4. 모폴로지 연산
```python
morph = cv2.morphologyEx(binary, cv2.MORPH_OPEN, kernel, iterations=2)
```
Erosion → Dilation 순서로 작은 잡티 제거.

### 3-5. 외곽선 검출 + 원형성 판별
```python
contours, _ = cv2.findContours(morph, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
circularity = 4 * np.pi * area / (perimeter ** 2)
```
원형성 0.6 이상만 동전으로 판정.

---

## 4. 사용 기법 정리

| 단계 | 함수 | 수업 챕터 |
|------|------|-----------|
| 그레이스케일 | `cv2.cvtColor()` | 기초 |
| 가우시안 블러 | `cv2.GaussianBlur()` | 04 영역처리 |
| 이진화 | `cv2.threshold()` + Otsu | 03 이진화 |
| 모폴로지 | `cv2.morphologyEx()` | 06~07 이진 영상 처리 |
| 외곽선 검출 | `cv2.findContours()` | 종합 |
| 원형성 계산 | 수식 직접 계산 | 종합 |

---

## 5. 결과

- 동전 3개 정확히 검출
- 배경 밝기 자동 감지로 다양한 환경 대응

---

## 6. 한계 및 개선 방향

| 한계 | 원인 | 개선 방향 |
|------|------|-----------|
| 동전 겹치면 인식 불가 | 이진화 단계에서 하나의 덩어리로 합쳐짐 | Watershed 알고리즘 적용 |
| 무늬 있는 배경에 취약 | Otsu 이진화 한계 | 적응형 이진화 적용 |