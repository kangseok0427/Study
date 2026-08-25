package ai0825;

import java.util.Scanner;

public class lab2 {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        double[] score = new double[5];
        double sum = 0;

        for (int i = 0; i < 5; i++) {
            System.out.print((i + 1) + "번 심사위원 점수 입력: ");
            score[i] = sc.nextDouble();
            sum += score[i];
        }

        System.out.println("평균 점수: " + (sum / 5));
    }
}
