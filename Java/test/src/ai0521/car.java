package ai0521;

public class car {
    private String product;
    private String name;
    private int displacement;
    private String color;
    private int price;

    public car() {

    }

    public car(String product, String name, int displacement, String color, int price) {
        this.product = product;
        this.name = name;
        this.displacement = displacement;
        this.color = color;
        this.price = price;
    }

    public String getProduct() {
        return product;
    }

    public void setProduct(String product) {
        this.product = product;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getDisplacement() {
        return displacement;
    }

    public void setDisplacement(int displacement) {
        this.displacement = displacement;
    }

    public String getColor() {
        return color;
    }

    public void setColor(String color) {
        this.color = color;
    }

    public int getPrice() {
        return price;
    }

    public void setPrice(int price) {
        this.price = price;
    }

    public void start() {
        System.out.println(name + " 시동을 켭니다.");
    }

    public void off() {
        System.out.println(name + " 시동을 끕니다.");
    }

    public void run() {
        System.out.println(name + " 주행을 시작합니다.");
    }

    public void stop() {
        System.out.println(name + " 주행을 멈춥니다.");
    }

    public void forward() {
        System.out.println(name + " 앞으로 갑니다.");
    }

    public void backward() {
        System.out.println(name + " 뒤로 갑니다.");
    }

    public void rotate(String direction) {
        System.out.println(name + " " + direction + "으로 회전합니다.");
    }
}
