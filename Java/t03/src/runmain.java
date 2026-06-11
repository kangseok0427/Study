public class runmain {
    public static void main(String[] args) {
        sportage sp = new sportage();

        System.out.println("차량 정보: " + Car.PRODUCT);
        System.out.println("제조사 주소: " + Car.ADDRESS);
        sp.Start();
        sp.upSpeed(50);
        sp.rotate("좌회전");
        sp.forward();
        sp.downSpeed(20);
        sp.Stop();
    }
    
}
