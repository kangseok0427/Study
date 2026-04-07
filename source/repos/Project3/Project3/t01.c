#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main(void) {
	
	m3();

	return 0;
}

int m1(void) {
	int input;
	printf("양수를 입력하세요. : ");
	scanf("%d", &input);

	if (input % 2 == 0) {
		printf("%d : 짝수입니다.", input);
	}

	else {
		printf("%d : 홀수입니다.", input);
	}
}

int m2(void) {
	int input;
	printf("점수를 입력하세요. : ");
	scanf("%d", &input);

	if (input >= 0 && input <= 100) {
		printf("%d점입니다.\n", input);
	}
	else {
		printf("0점에서 100점 사이를 입력하셔야 합니다.");
	}

	if (input >= 0 && input < 60) {
		printf("%d점은 F입니다.", input);
	}
}

int m3(void) {
	int input;
	printf("1, 2, 3을 입력하세요. : ");
	scanf("%d", &input);

	switch (input) {
		case 1: printf("GoodMorning"); break;
		case 2: printf("GoodAfterNoon"); break;
		case 3: printf("GoodNight"); break;
	}
}