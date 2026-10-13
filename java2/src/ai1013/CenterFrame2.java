package ai1013;

import java.awt.*;

public class CenterFrame2 {
    public static Point getLocation(int w, int h){
        Toolkit toolkit = Toolkit.getDefaultToolkit();
        Dimension screenSizeDim = toolkit.getScreenSize();

        int x = (screenSizeDim.width - w) / 2;
        int y = (screenSizeDim.height - h) / 2;

        return new Point(x, y);
    }
}
