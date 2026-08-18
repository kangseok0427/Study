package ai0611;

public class SportsCar extends car{
    public static void main(String[] args) {
        
    }

    @Override
    public void upSpeed(int value){
        if(speed + value > 200){
            speed = 200;
        } else {
            speed += value;
        }
    }
    
}
