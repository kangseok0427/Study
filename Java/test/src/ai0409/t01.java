package ai0409;

import java.util.Scanner;

public class t01 {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        double res1 = 0;
        double res2 = 0;
        double res3 = 0;

        System.out.print("자바 : ");
        res1 = s.nextDouble();

        System.out.print("모바일 : ");
        res2 = s.nextDouble();

        System.out.print("엑셀 : ");
        res3 = s.nextDouble();

        double avg = (res1 * 3 + res2 * 3 + res3 * 2) / (3 + 3 + 2);

        System.out.printf("평균 : %.2f\n", avg);

        s.close();
    }
}


