#include <stdio.h>

int main(void) {

	TestPrintf1();
	printf("\n");
	TestPrintf2();
	printf("\n");
	TestPrintf3();
	return 0;
}

int TestPrintf1(void) {

	//고정밀 부동 소수점
	long double a = 10.123456789;
	printf("지수 표기법 : %E", a);

	return 0;
}

int TestPrintf2(void) {

	//bool 초기버전
	_Bool a = 0;
	printf("삼항 연산자 : %s", a ? "True" : "False");

	return 0;
}

int TestPrintf3(void) {
	//긴 int
	long long a = 123456789123456789;
	printf("long long 표기법 : %lld", a);

	return 0;
}