package ai0922;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;

public class ImageFileCopy {
    public static void main(String[] args){
        try{
            FileInputStream fIn = new FileInputStream("mat.jpg");
            FileOutputStream fOut = new FileOutputStream("matCopy.jpg");

            int data;
            while ((data = fIn.read()) != -1){
                fOut.write((byte)data);
            }

            fIn.close();
            fOut.close();
        }catch (FileNotFoundException e){
            throw new RuntimeException(e);
        }catch (IOException e){
            throw new RuntimeException(e);
        }
    }
}
