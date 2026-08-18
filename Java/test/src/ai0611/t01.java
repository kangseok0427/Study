package ai0611;

import java.util.Scanner;

public class t01 {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);

        Bus bus = new Bus();
        SportsCar sportsCar = new SportsCar();

        while(true){
            System.out.print("차량을 선택하세요 (1: 버스, 2: 스포츠카, 종료하려면 -1): ");
            int choice = s.nextInt();
            if(choice == -1){
                break;
            }

            if(choice == 1){
                System.out.print("버스의 속도를 입력하세요: ");
                int speed = s.nextInt();
                bus.upSpeed(speed);
                System.out.println("입력된 속도: " + bus.speed);
            } else if(choice == 2){
                System.out.print("스포츠카의 속도를 입력하세요: ");
                int speed = s.nextInt();
                sportsCar.upSpeed(speed);
                System.out.println("입력된 속도: " + sportsCar.speed);
            } else {
                System.out.println("잘못된 선택입니다. 다시 시도하세요.");
            }
        }
        s.close();
    }
}
