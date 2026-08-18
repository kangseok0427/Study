#include <stdio.h>

int main(void) {
    int i = 10;
    int *p = &i;

    printf("Add p : %d\n", &p);
    printf("Value of p : %d\n", p);
    printf("Add i : %d\n", p);
    printf("Value of i : %d\n", *p);

    return 0;
}