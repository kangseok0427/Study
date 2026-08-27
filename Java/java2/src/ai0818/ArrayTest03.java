package ai0818;

import java.util.Arrays;

public class ArrayTest03 {
    public static void main(String[] args) {
        int[] arr1 = {12, 34, 56};
        arr1 = Arrays.copyOf(arr1, arr1.length + 2);

        for(int data : arr1) {
            System.out.print(data + " ");
        }
    }
}
