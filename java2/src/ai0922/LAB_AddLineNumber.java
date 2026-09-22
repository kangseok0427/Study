package ai0922;

import java.io.BufferedReader;
import java.io.FileReader;

public class LAB_AddLineNumber {
    public static void main(String[] args){
        try{
            BufferedReader br = new BufferedReader(new FileReader("mydata1.txt"));
            String line = "";
            int cnt = 1;

            while (true){
                line = br.readLine();
                if(line == null)
                    break;
                System.out.println(cnt++ + " : " + line);
            }

            br.close();
        } catch (Exception e){
            System.out.println("파일을 읽을 수 없습니다.");
        }
    }
}
