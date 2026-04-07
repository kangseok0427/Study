package ai0402;

import java.util.Scanner;

public class t04 {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        System.out.print("점수 입력 : ");
        int a = s.nextInt();

        if(a < 70) System.out.println("불합격입니다.");
        else System.out.println("합격입니다.");

        s.close();
    }
}
