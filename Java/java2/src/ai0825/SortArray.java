package ai0825;

import java.util.Arrays;
import java.util.Collections;

public class SortArray {
    public static void main(String[] args){
        Integer[] numArr = {77, 34, 23, 65, 12, 90, 45};
        Arrays.sort(numArr);
        for(int data : numArr){
            System.out.print(data + " ");
        }

        System.out.println();
        String[] strArr = {"홍길동", "김철수", "이영희", "박영수"};
        Arrays.sort(strArr);
        for(String data : strArr){
            System.out.print(data + " ");
        }

        System.out.println();
        Arrays.sort(strArr, Collections.reverseOrder());
        for(String data : strArr){
            System.out.print(data + " ");
        }
    }
}
