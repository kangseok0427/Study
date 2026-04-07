#include <stdio.h>

int main(void) {

	int a = 0, b = 1, c = 1;

	printf("logical operations 1 && 1 || 0 result : %d\n", 1 && 1 || 0);
	printf("logical operations 1 && 0 || 1 result : %d\n", 1 && 0 || 1);
	printf("logical operations 1 && 0 || 0 result : %d\n", 1 && 0 || 0);

	printf("logical operations 1 && 0 || 0 && 1 result : %d\n", b && a || a && c);
	printf("logical operations <1 && 0> || <0 && 1> result : %d\n", (b && a) || (a && c));

	printf("a < b && c > a result : %d\n", a < b && c > a);
	printf("a > b && c > a result : %d\n", a > b && c > a);
	printf("a > b || c > a result : %d\n", a > b || c > a);

	printf("(a > b) || (c > a) result : %d\n", (a > b) || (c > a));

	unsigned char lm = 1;
	unsigned char fm = 128;

	unsigned char input;
	scanf("%d", &input);

	printf("입력한 값 %d 의 첫 번째 비트는 %d 이다.\n", input, input & fm);
	printf("입력한 값 %d 의 마지막 비트는 %d 이다.\n", input, input & lm);

	printf("0 ~ 255 사이 값 중 짝수를 입력하시오. : \n");
	scanf("%d", &input);

	printf("입력한 값 %d의 첫 번째 비트는 %d이다.\n", input, input & fm);
	printf("입력한 값의 첫 번째 비트 값만 바꾸면 입력한 값은 %d가 된다.\n", input ^ fm);
	printf("입력한 값의 마지막 비트 값을 바꾸면 입력한 값은 %d가 된다.\n", input | lm);

	int d, e, f, g;
	int x = 10, y = 7;

	d = x & y;
	e = x | y;
	f = x ^ y;
	g = ~x;

	printf("비트곱 x & y의 결과 : %d\n", d);
	printf("비트합 x | y의 결과 : %d\n", e);
	printf("베타적 논리합 x ^ y의 결과 : %d\n", f);
	printf("비트 반전 ~x의 결과 : %d\n", g);

	return 0;
}