package ai0818;

import java.util.Arrays;

public class ArrayTest03 {
    public static void main(String[] args) {
        int[] arr1 = {12, 34, 56};
        arr1 = Arrays.copyOf(arr1, arr1.length + 2);

        for (int i = 0; i < arr1.length; i++) {
            System.out.println(arr1[i]);
        }
    }
}
