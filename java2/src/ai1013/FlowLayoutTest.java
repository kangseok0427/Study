package ai1013;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

public class FlowLayoutTest extends JFrame {
    public FlowLayoutTest(){
        setTitle("FlowLayout");
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLayout(new FlowLayout(FlowLayout.RIGHT, 15, 15));

        ArrayList<JButton> list = new ArrayList<JButton>();
        Color[] colors = {Color.RED, Color.ORANGE, Color.YELLOW, Color.GREEN, Color.BLUE};

        for(int i = 1; i <= 5; i++){
            JButton btn = new JButton("버튼"+(i));
            Color color = colors[i - 1];
            btn.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    getContentPane().setBackground(color);
                }
            });
            list.add(btn);
            add(btn);
        }

        int w = 250, h = 250;
        Point location = CenterFrame2.getLocation(w, h);
        setSize(w, h);
        setLocation(location);
        setVisible(true);
    }

    public static void main(String[] args){
        new FlowLayoutTest();
    }
}
