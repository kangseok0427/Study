package ai1028;

import javax.swing.*;
import java.awt.*;

public class GraphicPanel extends JPanel {

    public GraphicPanel(){
        setBackground(Color.WHITE);
    }

    @Override
    protected void paintComponent(Graphics g){
        super.paintComponent(g);
        g.setColor(Color.GREEN);
        g.drawLine(50, 30, 250, 30);

        g.setFont(new Font("숨고딕",Font.BOLD, 30));
        g.drawString("Hi everyone!", 30, 30);

        g.setColor(Color.ORANGE);
        g.fillRect(30, 50, 200, 250);
        g.drawRect(250, 50, 200, 200);

        g.setColor(Color.MAGENTA);
        g.drawOval(30, 50, 200, 250);
        g.fillOval(250, 50, 200, 200);

        g.setColor(Color.BLUE);
        int[] xPoints = {250, 350, 450};
        int[] yPoints = {150, 50, 150};
        g.fillPolygon(xPoints, yPoints, xPoints.length);

        g.setColor(Color.RED);
        int[] yPoints2 = {150, 250, 150};
        g.fillPolygon(xPoints, yPoints2, xPoints.length);
    }
}
