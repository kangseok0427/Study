package ai0922;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

public class LAB_Decode {
    public static void main(String[] args) {
        try {
            BufferedReader br = new BufferedReader(new FileReader("secure.txt"));
            FileWriter fw = new FileWriter("decode.txt");
            String line;

            while ((line = br.readLine()) != null) {
                String decode = "";
                for (int i = 0; i < line.length(); i++) {
                    int num = line.charAt(i);
                    num -= 100;
                    decode += (char) num;
                }
                fw.write(decode + "\n");
            }

            br.close();
            fw.close();
            System.out.println("decode.txt에 복호화된 문자열 저장 완료");
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
