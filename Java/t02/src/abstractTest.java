public abstract class abstractTest {
    String name;
    int weight;
    int height;

    public void eat(String food){
        System.out.println(" eats " + food);
    }

    public void sleep(int hours){
        System.out.println(" sleeps for " + hours + " hours");
    }

    public abstract void study();
}
