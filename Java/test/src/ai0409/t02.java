package ai0409;

public class t02 {
    public static void main(String[] args) {
        byte bt = -128;
        short st = 300;

        st = bt;
        int it = st;
        System.out.println("it : " + it);

        long lg = 700000000;

        float fl = 1000;
        fl = lg;
        fl = 1000.0f;
        fl = 1000.0F;
        fl = (float)1000.0;

        double dl = 2000;
        dl = fl;
        dl = bt;
        dl = 207.999;

        char c = 'A';
        System.out.println(c + 1);
        System.out.println((char)(c + 1));
        System.out.println(c);
        System.out.println((int)c);

        boolean b = true;
        System.out.println(b);
        System.out.println(!b);

        System.out.println(bt == st);

    }
}
