package ai0521;

public class field {
    public static void main(String[] args) {
        Rabbit rabbit1 = new Rabbit("토끼1", 2, "흰색", 0, 0);
        Rabbit rabbit2 = new Rabbit("토끼2", 3, "회색", 0, 0);

        System.out.println("토끼 정보:");
        System.out.println("이름: " + rabbit1.getName());
        System.out.println("나이: " + rabbit1.getAge() + "살");
        System.out.println("색상: " + rabbit1.getColor());
        System.out.println("위치: (" + rabbit1.getPositionX() + ", " + rabbit1.getPositionY() + ")");

        System.out.println();

        rabbit1.setPosition(5, 5);
        rabbit1.eat();
        rabbit1.hop();
        rabbit1.sleep();

        System.out.println();

        System.out.println("토끼 정보:");
        System.out.println("이름: " + rabbit2.getName());
        System.out.println("나이: " + rabbit2.getAge() + "살");
        System.out.println("색상: " + rabbit2.getColor());
        System.out.println("위치: (" + rabbit2.getPositionX() + ", " + rabbit2.getPositionY() + ")");
        System.out.println();

        rabbit2.setPosition(10, 10);
        rabbit2.eat();
        rabbit2.hop();
        rabbit2.sleep();
    }
}
