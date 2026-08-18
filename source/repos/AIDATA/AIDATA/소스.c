#include <stdio.h>

int add(int, int);

int main(void) {

	printf(add(1, 2));
	printf("Hello World!\n");

	return 0;
}

int add(int i, int j) {
	return i + j;
}