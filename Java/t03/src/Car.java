public interface Car {
    public static final String PRODUCT = "KIA";
    String ADDRESS = "서울시 강남구 테헤란로 123";

    public void Start();
    public void Stop();
    public void upSpeed(int speed);
    public void downSpeed(int speed);
    public void rotate(String direction);
    public void forward();
    public void backward();
}
