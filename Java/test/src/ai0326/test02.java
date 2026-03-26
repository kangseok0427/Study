package ai0326;

import java.util.Scanner;

public class test02 {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        System.out.print("이름 입력 : ");
        String n = s.next();

        System.out.print("키 입력 : ");
        double h = s.nextDouble();

        System.out.print("몸무게 입력 : ");
        double w = s.nextDouble();

        double bmi = w / Math.pow(h/100, 2);

        System.out.println(n + "님의 BMI지수는 " + Math.round(bmi * 100) / 100.0 + "입니다.");

        s.close();
    }
}
