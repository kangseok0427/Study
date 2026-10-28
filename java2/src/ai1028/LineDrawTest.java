package ai1028;

import ai1013.CenterFrame2;

import javax.swing.*;
import java.awt.*;

public class LineDrawTest extends JFrame {

    public LineDrawTest(){
        setTitle("선 그리기");
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        add("Center", new DrawPanel());

        int w = 400, h = 400;
        Point location = CenterFrame2.getLocation(w, h);
        setBounds(location.x, location.y, w, h);
        setVisible(true);
    }

    public static void main(String[] args){
        new LineDrawTest();
    }
}
