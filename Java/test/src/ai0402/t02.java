package ai0402;

import java.util.Scanner;

public class t02 {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        System.out.print("파운드 (lb) 입력 : ");
        double p = s.nextDouble();

        System.out.print("킬로그램 (kg) 입력 : ");
        double k = s.nextDouble();

        System.out.printf("%.1f 파운드(lb) 는 %.3f 킬로그램(kg)입니다.\n", p, p * 0.453592);
        System.out.printf("%.1f 킬로그램(kg) 는 %.3f 파운드(lb)입니다.", k, k * 2.204623);

        s.close();
    }
}
