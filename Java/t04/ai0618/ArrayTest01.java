package Java.t04.ai0618;

import java.util.Scanner;

public class ArrayTest01 {
    public static void main(String[] args){
        int[] scores = new int[5];
        String[] subjects = {"프로그래밍언어실습", "데이터베이스", "융합UI실습", "인공지능개론", "직업과경력개발"};
        int k = 0;

        Scanner s = new Scanner(System.in);

        for(int i = 0; i < scores.length; i++){
            System.out.print(subjects[i] + " 성적 입력 (정수) : ");
            scores[i] = s.nextInt();
        }

        int m = 0;
        for(int score : scores){
            System.out.print(subjects[0] + "성적 : " + score + "  ");
            k += score;
            m += 1;
        }
        System.out.println("\n합계 : " + k);
        int l = k/5;
        System.out.println("\n평균 : " + l);

        s.close();
    }
}
