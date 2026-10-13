package ai1013;

import ai1006.CenterFrame;

import javax.swing.*;
import java.awt.*;

public class ListComboBoxTest extends JFrame {
    public ListComboBoxTest(){
        setTitle("리스트와 콤보박스 테스트");
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLayout(new FlowLayout());
        String[] items = {"강아지", "고양이", "토끼"};
        JList<String> list = new JList<>(items);
        JComboBox<String> comboBox = new JComboBox<>(items);

        add(comboBox);
        add(list);

        int w = 250, h = 250;
        int[] locations = CenterFrame.getLocation(w, h);
        setBounds(locations[0], locations[1], w, h);
        setVisible(true);
    }

    public static void main(String[] args){
        new ListComboBoxTest();
    }
}
