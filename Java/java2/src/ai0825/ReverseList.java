package ai0825;

import java.util.Arrays;
import java.util.Collections;

public class ReverseList {
    public static void main(String[] args){
        String[] newjeans = {"민지", "하니", "다니엘", "해린", "혜인"};
        System.out.println("원본 배열 : " + Arrays.toString(newjeans));
        Collections.reverse(Arrays.asList(newjeans));
        System.out.println("역순 배열 : " + Arrays.toString(newjeans));
    }
}
