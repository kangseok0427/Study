package ai1013;

import ai1006.CenterFrame;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ItemEvent;
import java.awt.event.ItemListener;

public class ComboBoxImageTest extends JFrame {
    JComboBox<String> comboBox;
    JLabel lbl;
    ImageIcon[] imageIcons;

    public ComboBoxImageTest(){
        setTitle("콤보박스 이미지 테스트");
        setDefaultCloseOperation(EXIT_ON_CLOSE);

        String[] items = {"강아지", "고양이", "코뿔소"};
        comboBox = new JComboBox<>(items);
        add("North", comboBox);

        imageIcons = new ImageIcon[]{
            new ImageIcon("D:/Study/java2/imgs/img1.png"),
            new ImageIcon("D:/Study/java2/imgs/img0.png"),
            new ImageIcon("D:/Study/java2/imgs/img2.png")
        };

        for(int i = 0; i < imageIcons.length; i++){
            Image image = imageIcons[i].getImage().getScaledInstance(200, -1, Image.SCALE_SMOOTH);
            imageIcons[i] = new ImageIcon(image);
        }

        lbl = new JLabel(imageIcons[0]);
        lbl.setHorizontalAlignment(SwingConstants.CENTER);
        add("Center", lbl);
        comboBox.addItemListener(comboListener);

        int w = 250, h = 300;
        int[] locations = CenterFrame.getLocation(w, h);
        setBounds(locations[0], locations[1], w, h);
        setVisible(true);
    }

    ItemListener comboListener = new ItemListener() {
        @Override
        public void itemStateChanged(ItemEvent e) {
            if(e.getStateChange() == ItemEvent.SELECTED){
                int selectedIndex = comboBox.getSelectedIndex();
                lbl.setIcon(imageIcons[selectedIndex]);
            }
        }
    };

    public static void main(String[] args){
        new ComboBoxImageTest();
    }
}
