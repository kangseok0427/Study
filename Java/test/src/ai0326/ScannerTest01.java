package ai0326;

import java.sql.SQLOutput;
import java.util.Calendar;
import java.util.Scanner;

public class ScannerTest01 {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        Calendar c = Calendar.getInstance();
        System.out.print("출생년도를 입력하세요. : ");
        int num = c.get(Calendar.YEAR) - s.nextInt();

        System.out.println("나이는 " + num + "입니다.");

        s.close();
    }
}
