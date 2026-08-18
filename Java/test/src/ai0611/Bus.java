package ai0611;

public class Bus extends car{
    public static void main(String[] args) {
        
    }

    @Override
    public void upSpeed(int value){
        if(speed + value > 60){
            speed = 60;
        } else {
            speed += value;
        }
    }
}
