import cv2
import numpy as np
import matplotlib.pyplot as plt

plt.rcParams['font.family'] = 'Malgun Gothic'
plt.rcParams['axes.unicode_minus'] = False

# ─────────────────────────────────────────
# 1단계. 이미지 불러오기
# ─────────────────────────────────────────
img_bgr = cv2.imread("coin.jpg")

# ─────────────────────────────────────────
# 2단계. 업스케일 (작은 사진 대응)
# ─────────────────────────────────────────
img_bgr = cv2.resize(img_bgr, None, fx=2, fy=2, interpolation=cv2.INTER_CUBIC)

# ─────────────────────────────────────────
# 3단계. 그레이스케일 변환
# ─────────────────────────────────────────
gray = cv2.cvtColor(img_bgr, cv2.COLOR_BGR2GRAY)

# ─────────────────────────────────────────
# 4단계. 가우시안 블러
# ─────────────────────────────────────────
blur = cv2.GaussianBlur(gray, (11, 11), 0)

# ─────────────────────────────────────────
# 5단계. 이진화 (Otsu)
# ─────────────────────────────────────────
_, binary = cv2.threshold(blur, 0, 255, cv2.THRESH_BINARY_INV + cv2.THRESH_OTSU)

# ─────────────────────────────────────────
# 6단계. 모폴로지 연산 (잡티 제거)
# ─────────────────────────────────────────
kernel = np.ones((3, 3), np.uint8)
morph = cv2.morphologyEx(binary, cv2.MORPH_OPEN, kernel, iterations=2)

# ─────────────────────────────────────────
# 7단계. 외곽선 검출 + 동전 판별
# ─────────────────────────────────────────
contours, hierarchy = cv2.findContours(morph, cv2.RETR_CCOMP, cv2.CHAIN_APPROX_SIMPLE)

result = img_bgr.copy()
coin_count = 0

# 이미지 크기 기준 상대적 면적 필터
img_area = img_bgr.shape[0] * img_bgr.shape[1]
MIN_AREA = img_area * 0.005
MAX_AREA = img_area * 0.15
MIN_CIRCULARITY = 0.55

for i, contour in enumerate(contours):
    if hierarchy[0][i][3] != -1:
        continue

    area = cv2.contourArea(contour)
    if area < MIN_AREA or area > MAX_AREA:
        continue

    perimeter = cv2.arcLength(contour, True)
    if perimeter == 0:
        continue

    circularity = 4 * np.pi * area / (perimeter ** 2)
    if circularity < MIN_CIRCULARITY:
        continue

    coin_count += 1

    has_hole = hierarchy[0][i][2] != -1
    kind = "(구멍)" if has_hole else ""

    cv2.drawContours(result, [contour], -1, (0, 255, 0), 3)

    M = cv2.moments(contour)
    if M["m00"] != 0:
        cx = int(M["m10"] / M["m00"])
        cy = int(M["m01"] / M["m00"])
        cv2.putText(result, str(coin_count), (cx - 15, cy + 10),
                    cv2.FONT_HERSHEY_SIMPLEX, 1.0, (0, 0, 255), 2)
        if kind:
            cv2.putText(result, kind, (cx - 30, cy + 35),
                        cv2.FONT_HERSHEY_SIMPLEX, 0.55, (255, 0, 0), 2)

print(f"검출된 동전 개수: {coin_count}개")

# ─────────────────────────────────────────
# 8단계. 단계별 결과 시각화
# ─────────────────────────────────────────
titles = ["원본", "그레이스케일", "가우시안 블러", "이진화 (Otsu)", "모폴로지 연산", f"결과 ({coin_count}개 검출)"]
images = [
    cv2.cvtColor(img_bgr, cv2.COLOR_BGR2RGB),
    gray, blur, binary, morph,
    cv2.cvtColor(result, cv2.COLOR_BGR2RGB),
]
cmaps = [None, "gray", "gray", "gray", "gray", None]

plt.figure(figsize=(15, 8))
for j in range(6):
    plt.subplot(2, 3, j + 1)
    plt.imshow(images[j], cmap=cmaps[j])
    plt.title(titles[j])
    plt.axis("off")

plt.suptitle(f"동전 개수 세기 결과: {coin_count}개", fontsize=16)
plt.tight_layout()
plt.savefig("result.png", dpi=150)
plt.show()