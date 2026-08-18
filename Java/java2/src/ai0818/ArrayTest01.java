package ai0818;

import java.util.Scanner;

public class ArrayTest01 {
    public static void main(String[] args) {
        Scanner s1 = new Scanner(System.in);

        int[] numArr = new int[5];
        int sum = 0;

        for (int i = 0; i < numArr.length; i++) {
            System.out.print((i + 1) + ". Enter an integer: ");
            numArr[i] = s1.nextInt();
            sum += numArr[i];
        }

        for (int i = 0; i < numArr.length; i++) {
            System.out.print(numArr[i]);
            if (i < numArr.length - 1) {
                System.out.print(" + ");
            }
        }
        System.out.println(" = " + sum);

        s1.close();
    }
}
