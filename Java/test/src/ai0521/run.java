package ai0521;

public class run {
    public static void main(String[] args) {
        car car1 = new car("현대자동차", "그랜저", 3000, "검정", 35000000);

        System.out.println("차량 정보:");
        System.out.println("제조사: " + car1.getProduct());
        System.out.println("모델명: " + car1.getName());
        System.out.println("배기량: " + car1.getDisplacement() + "cc");
        System.out.println("색상: " + car1.getColor());
        System.out.println("가격: " + car1.getPrice() + "원");

        System.out.println();

        car1.start();
        car1.run();
        car1.rotate("좌");
        car1.stop();
        car1.off();

        car car2 = new car("기아자동차", "K5", 2000, "흰색", 25000000);
        System.out.println("차량 정보:");
        System.out.println("제조사: " + car2.getProduct());
        System.out.println("모델명: " + car2.getName());
        System.out.println("배기량: " + car2.getDisplacement() + "cc");
        System.out.println("색상: " + car2.getColor());
        System.out.println("가격: " + car2.getPrice() + "원");

        System.out.println();

        car2.start();
        car2.run();
        car2.rotate("우");
        car2.stop();
        car2.off();
    }
    
}
