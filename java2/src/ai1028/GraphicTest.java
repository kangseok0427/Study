package ai1028;

import ai1013.CenterFrame2;

import javax.swing.*;
import java.awt.*;

public class GraphicTest extends JFrame {

    public GraphicTest(){
        setTitle("도형 그리기 연습");
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        add("Center", new GraphicPanel());

        int w = 500, h = 500;
        Point location = CenterFrame2.getLocation(w, h);
        setBounds(location.x, location.y, w, h);
        setVisible(true);
    }

    public static void main(String[] args){
        new GraphicTest();
    }
}
