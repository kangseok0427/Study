package ai0922;

import java.io.FileReader;
import java.io.FileWriter;

public class LAB_FileCopy {
    public static void main(String[] args) {
        try {
            FileReader input = new FileReader("mydata1.txt");
            FileWriter output = new FileWriter("newFile.txt");

            int data;
            while ((data = input.read()) != -1) {
                output.write(data);
            }

            input.close();
            output.close();

            System.out.println("--- mydata1.txt가 newFile.txt로 복사되었음 ---");
        } catch (Exception e) {
            System.out.println("파일을 복사할 수 없습니다.");
        }
    }
}
