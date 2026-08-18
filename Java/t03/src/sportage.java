public class sportage implements Car {
    public String CarName = "스포티지";
    public int speed;

    @Override
    public void Start() {
        System.out.println(CarName + " 시동을 켭니다.");
    }

    @Override
    public void Stop() {
        System.out.println(CarName + " 시동을 끕니다.");
    }

    @Override
    public void upSpeed(int speed) {
        this.speed += speed;
        System.out.println(CarName + " 속도가 " + this.speed + "km/h로 증가합니다.");
    }

    @Override
    public void downSpeed(int speed) {
        this.speed -= speed;
        System.out.println(CarName + " 속도가 " + this.speed + "km/h로 감소합니다.");
    }

    @Override
    public void rotate(String direction) {
        System.out.println(CarName + "가 " + direction + "으로 회전합니다.");
    }

    @Override
    public void forward() {
        System.out.println(CarName + "가 전진합니다.");
    }

    @Override
    public void backward() {
        System.out.println(CarName + "가 후진합니다.");
    }
}
