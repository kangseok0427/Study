package Java.t04.ai0618;

import java.util.Arrays;

public class ArrayTest02 {
    public static void main(String[] args){
        String[] subjects = {"프로그래밍언어실습", "데이터베이스", "융합UI실습", "인공지능개론", "직업과경력개발"};

        System.out.println("현재 배열의 길이 : " + subjects.length);
        System.out.println("현재 배열의 내용");
        for(String subs : subjects) System.out.print(subs + "  ");
        System.out.println();

        subjects = Arrays.copyOf(subjects, subjects.length + 2);
        subjects[subjects.length - 2] = "영상인공지능처리";
        subjects[subjects.length - 1] = "직업과경력개발";

        System.out.println("새로운 배열의 길이 : " + subjects.length);
        System.out.println("새로운 배열의 내용");
        for(String subs : subjects) System.out.print(subs + "  ");
        System.out.println();
    }
}
