package ai0922;

import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;

public class LAB_EncryptText {
    public static void main(String[] args) {
        try {
            Scanner s = new Scanner(System.in);
            FileWriter fw = new FileWriter("secure.txt");

            while (true) {
                System.out.print("암호화할 문자열 입력(종료 : exit) : ");
                String inStr = s.nextLine();

                if (inStr.equals("exit"))
                    break;

                String secure = "";
                for (int i = 0; i < inStr.length(); i++) {
                    int num = inStr.charAt(i);
                    num += 100;
                    secure += (char) num;
                }

                fw.write(secure + "\n");
            }

            fw.close();
            s.close();
            System.out.println("secure.txt에 암호화된 문자열 저장 완료");
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
