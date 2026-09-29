package ai0929;

import java.io.*;

public class ThrowTest2 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new FileReader("mydata1.txt"));

        while(true){
            String line = br.readLine();
            if(line == null)
                break;
            System.out.println(line);
        }
    }
}
