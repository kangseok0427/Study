package ai0521;

public class Rabbit {
    private String name;
    private int age;
    private String color;
    private int xPosition;
    private int yPosition;

    public Rabbit() {

    }

    public Rabbit(String name, int age, String color, int xPosition, int yPosition) {
        this.name = name;
        this.age = age;
        this.color = color;
        this.xPosition = xPosition;
        this.yPosition = yPosition;
    }

    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public int getAge() {
        return age;
    }
    public void setAge(int age) {
        this.age = age;
    }
    public String getColor() {
        return color;
    }
    public void setColor(String color) {
        this.color = color;
    }
    public void setPosition(int x, int y) {
        this.xPosition = x;
        this.yPosition = y;
        System.out.println(name + "의 위치가 (" + x + ", " + y + ")로 설정되었습니다.");
    }
    public int getPositionX() {
        return xPosition;
    }
    public int getPositionY() {
        return yPosition;
    }

    public void move(int x, int y) {
        this.xPosition += x;
        this.yPosition += y;
        System.out.println(name + "이(가) (" + x + ", " + y + ")만큼 이동했습니다. 현재 위치: (" + xPosition + ", " + yPosition + ")");
    }
    public void eat() {
        System.out.println(name + "이(가) 당근을 먹습니다.");
    }
    public void sleep() {
        System.out.println(name + "이(가) 잠을 잡니다.");
    }
    public void hop() {
        System.out.println(name + "이(가) 깡충깡충 뛰어다닙니다.");
    }
}
