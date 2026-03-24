#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main(void) {
	int a, b, sum = 0;
	printf("enter int : ");
	scanf("%d", &a);

	b = (a + 1) / 2;
	sum = b * b;

	printf("The sum of odd numbers from 1 to %d is %d. \n", a, sum);

	return 0;
}