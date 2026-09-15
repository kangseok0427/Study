package ai0915;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

public class StringBuilder {
    public static void main(String[] args){
        try(BufferedReader br = new BufferedReader(
                new FileReader("D:/FileTest/myFile.txt", StandardCharsets.UTF_8))){

            String line = "";

            while((line = br.readLine()) != null){
                System.out.println(line);
            }

        }catch(FileNotFoundException e){
            System.out.println("파일을 찾을 수 없습니다. 파일 경로를 확인해주세요.");
        }catch(IOException e){
            System.out.println("파일을 읽는 중 문제가 발생했습니다.");
        }
    }
}
