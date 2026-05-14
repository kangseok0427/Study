package ai0514;

import java.util.Random;
import java.util.Scanner;

public class t06 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        Random rand = new Random();
        int i = 0;
        int j = 1;
        int rnd = rand.nextInt(10) + 1;

        System.out.println("게임 : 1 ~ 10 사이의 숫자를 맞춰라!");

        while (true){

            System.out.print(j + "회자 게임! 숫자를 입력하세요 : ");
            i = scanner.nextInt();

            if(rnd == i) {
                System.out.println("정답입니다!");
                break;
            }

            System.out.println("실패입니다!");
            j++;
        }
        scanner.close();
    }
}
