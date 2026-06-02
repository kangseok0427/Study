import cv2
import numpy as np
import matplotlib.pyplot as plt

plt.rcParams['font.family'] = 'Malgun Gothic'
plt.rcParams['axes.unicode_minus'] = False

# ─────────────────────────────────────────
# 1단계. 이미지 불러오기
# ─────────────────────────────────────────
img_bgr = cv2.imread("coin.jpg")

# 테스트 이미지 쓸 때는 아래 주석 해제
# img_bgr = np.ones((600, 800, 3), dtype=np.uint8) * 255
# coins = [(150,150,60),(320,150,50),(500,160,70),(650,150,55),(220,350,65),(420,360,60),(600,350,75)]
# for x, y, r in coins:
#     cv2.circle(img_bgr, (x, y), r, (0, 0, 0), 3)

# ─────────────────────────────────────────
# 2단계. 그레이스케일 변환
# ─────────────────────────────────────────
gray = cv2.cvtColor(img_bgr, cv2.COLOR_BGR2GRAY)

# ─────────────────────────────────────────
# 3단계. 가우시안 블러
# ─────────────────────────────────────────
blur = cv2.GaussianBlur(gray, (11, 11), 0)

# ─────────────────────────────────────────
# 4단계. 이진화 (배경 밝기 자동 감지)
# ─────────────────────────────────────────
mean_brightness = np.mean(gray)
if mean_brightness >= 127:
    flag = cv2.THRESH_BINARY_INV + cv2.THRESH_OTSU
else:
    flag = cv2.THRESH_BINARY + cv2.THRESH_OTSU

_, binary = cv2.threshold(blur, 0, 255, flag)

# ─────────────────────────────────────────
# 5단계. 모폴로지 연산
# ─────────────────────────────────────────
kernel = np.ones((3, 3), np.uint8)
morph = cv2.morphologyEx(binary, cv2.MORPH_OPEN, kernel, iterations=2)

# ─────────────────────────────────────────
# 6단계. 외곽선 검출 + 동전 판별
# ─────────────────────────────────────────
contours, _ = cv2.findContours(morph, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)

result = img_bgr.copy()
coin_count = 0

for contour in contours:
    area = cv2.contourArea(contour)
    if area < 500:
        continue

    perimeter = cv2.arcLength(contour, True)
    if perimeter == 0:
        continue

    circularity = 4 * np.pi * area / (perimeter ** 2)
    if circularity < 0.6:
        continue

    coin_count += 1

    cv2.drawContours(result, [contour], -1, (0, 255, 0), 3)

    M = cv2.moments(contour)
    if M["m00"] != 0:
        cx = int(M["m10"] / M["m00"])
        cy = int(M["m01"] / M["m00"])
        cv2.putText(result, str(coin_count), (cx - 10, cy + 10),
                    cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 2)

print("검출된 동전 개수:", coin_count)

# ─────────────────────────────────────────
# 7단계. 단계별 결과 시각화
# ─────────────────────────────────────────
titles = ["원본", "그레이스케일", "가우시안 블러", "이진화", "모폴로지", "결과"]
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

plt.suptitle(f"검출된 동전 개수: {coin_count}개", fontsize=16)
plt.tight_layout()
plt.savefig("result.png")
plt.show()