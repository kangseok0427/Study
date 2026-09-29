package ai0929;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

public class ThrowTest1 {
    public static void main(String[] args){
        try{
            BufferedReader br = new BufferedReader(new FileReader("mydata1.txt"));

            while(true){
                String line = br.readLine();
                if(line == null)
                    break;
                System.out.println(line);
            }
        }catch (FileNotFoundException e){
            System.out.println("파일을 못찾음.");
        }catch(IOException e){
            System.out.println("한줄 읽어올때 문제가 발생함.");
        }
    }
}
