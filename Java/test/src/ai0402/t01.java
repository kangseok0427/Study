package ai0402;

import java.util.Scanner;

public class t01 {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        System.out.print("정수 1 : ");
        int a = s.nextInt();

        System.out.print("정수 2 : ");
        int b = s.nextInt();

        System.out.println(a + " + " + b + " = " + (a + b));
        System.out.println(a + " - " + b + " = " + (a - b));
        System.out.println(a + " * " + b + " = " + (a * b));
        System.out.println(a + " / " + b + " = " + ((double) a / (double) b));
        System.out.println(a + " % " + b + " = " + (a % b));

        s.close();
    }
}
