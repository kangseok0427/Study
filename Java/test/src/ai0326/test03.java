package ai0326;

import java.util.Scanner;

public class test03 {
    public static void main(String[] args) {
        Scanner ss = new Scanner(System.in);
        Scanner si = new Scanner(System.in);

        System.out.print("받는 사람 : ");
        String a = ss.next();

        System.out.print("주소 : ");
        String b = ss.next();

        System.out.print("무게 (g) : ");
        int c = si.nextInt();
        int d = 5 * c;

        System.out.println("받는 사람 ==>" + a);
        System.out.println("주소 ==>" + b);
        System.out.println("배송비 ==>" + d + "원");

        ss.close();
    }
}
