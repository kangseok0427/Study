package ai0416;

import java.util.ArrayList;
import java.util.List;

public class t01 {
    public static void main(String[] args) {
        String s = new String("        한국        폴리텍 대학    서울        정수         캠퍼스             ");

        System.out.println(s);

        s = s.replaceAll(" ", "");
        System.out.println(s);

        s = "인공지능소프트웨어학과 1학년";
        System.out.println("\"지능\"의 인덱스 번호 : " + s.indexOf("지능"));
        System.out.println("\"웨\"의 인덱스 번호 : " + s.indexOf("웨"));

        s = "한국에는 한국 폴리텍대학이 한국 전체에 많은 곳에 캠퍼스가 위치해 있습니다.";
        System.out.println("s의 4번 위치부터 찾아서 한국 이라는 문자열의 번호 : " + s.indexOf("한국", 4));

        s = "서울정수";

        System.out.println("전체 문자열의 길이 : " + s.length());
        System.out.println(s.charAt(0));
        System.out.println(s.charAt(1));
        System.out.println(s.charAt(2));
        System.out.println(s.charAt(3));

        System.out.println();

        System.out.println(s.substring(1, 3));

        List<String> l1 = new ArrayList<>();

        for(int i = s.length(); i > 0; i-- ){
            l1.add(Character.toString(s.charAt(i - 1)));
        }

        System.out.println(String.join("", l1));
    }
}
