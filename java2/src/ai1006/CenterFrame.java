package ai1006;

import java.awt.*;

public class CenterFrame {
    public static int[] getLocation(int w, int h) {
        Dimension screen = Toolkit.getDefaultToolkit().getScreenSize();

        int x = (screen.width - w) / 2;
        int y = (screen.height - h) / 2;

        return new int[]{x, y};
    }
}
