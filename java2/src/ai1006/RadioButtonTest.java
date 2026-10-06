package ai1006;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ItemEvent;
import java.awt.event.ItemListener;

public class RadioButtonTest extends JFrame{
    ImageIcon[] imageIcons;
    JLabel lbl;
    int i;
    int selectedIndex;
    JRadioButton[] radios;

    public RadioButtonTest(){
        setTitle("라디오버튼 테스트");
        setDefaultCloseOperation(EXIT_ON_CLOSE);

        JPanel panNorth = new JPanel();
        String[] animals = {"고양이", "강아지", "코뿔소"};
        radios = new JRadioButton[animals.length];

        imageIcons = new ImageIcon[animals.length];
        lbl = new JLabel();

        i = 0;
        for(String animal:animals){
            imageIcons[i] = new ImageIcon("imgs/img" + i + ".png");
            radios[i] = new JRadioButton(animal);
            radios[i].addItemListener(radioListener);
            panNorth.add(radios[i++]);
        }

        lbl.setIcon(imageIcons[0]);
        add("North", panNorth);
        add("Center",lbl);

        setLayout(new FlowLayout());
        int w = 500, h = 500;
        int[] location = CenterFrame.getLocation(w, h);
        setBounds(location[0], location[1], w, h);
        setVisible(true);
    }

    public static void main(String[] args){
        new RadioButtonTest();
    }

    ItemListener radioListener = new ItemListener() {
        @Override
        public void itemStateChanged(ItemEvent e) {
            JRadioButton selectRadio = (JRadioButton) e.getSource();
            if(selectRadio == radios[0]) selectedIndex = 0;
            else if(selectRadio == radios[1]) selectedIndex = 1;
            else selectedIndex = 2;
            lbl.setIcon(imageIcons[selectedIndex]);
        }
    };
}
