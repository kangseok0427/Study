package ai0514;

import java.util.Scanner;

public class t04 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        while (true){
            System.out.print("이름을 입력하세요 : ");
            String name = scanner.next();

            if(name.equals("exit")) break;

            System.out.print("키를 입력하세요 (cm): ");
            double heightCm = scanner.nextDouble();

            System.out.print("몸무게를 입력하세요 (kg): ");
            double weight = scanner.nextDouble();

            // 키를 cm에서 m로 변환
            double heightM = heightCm / 100;

            // BMI 계산 공식: kg / (m * m)
            double bmi = weight / (heightM * heightM);

            System.out.printf(name + "님, 당신의 BMI는: %.2f\n", bmi);

            // 비만도 판정
            if (bmi < 18.5) {
                System.out.println("저체중입니다.");
            } else if (bmi < 23) {
                System.out.println("정상입니다.");
            } else if (bmi < 25) {
                System.out.println("과체중입니다.");
            } else if (bmi < 30) {
                System.out.println("비만입니다.");
            } else {
                System.out.println("고도비만입니다.");
            }
        }

        scanner.close();
    }
}
