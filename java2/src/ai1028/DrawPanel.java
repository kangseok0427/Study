package ai1028;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

public class DrawPanel extends JPanel implements MouseListener {
    int x1, y1, x2, y2;
    boolean drawn = false;

    public DrawPanel(){
        setBackground(Color.YELLOW);
        addMouseListener(this);
    }

    @Override
    protected void paintComponent(Graphics g){
        //super.paintComponent(g);
        g.setColor(Color.BLACK);
        if(drawn){
            g.drawLine(x1, y1, x2, y2);
        }
    }

    @Override
    public void mousePressed(MouseEvent e){
        x1 = e.getX();
        y1 = e.getY();
    }

    @Override
    public void mouseReleased(MouseEvent e){
        x2 = e.getX();
        y2 = e.getY();
        drawn = true;
        repaint();
    }

    @Override
    public void mouseClicked(MouseEvent e){
    }

    @Override
    public void mouseEntered(MouseEvent e){
    }

    @Override
    public void mouseExited(MouseEvent e){
    }
}
