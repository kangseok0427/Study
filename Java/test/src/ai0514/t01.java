package ai0514;

public class t01 {
    public static void main(String[] args) {
        for(int j = 1; j < 10; j++){
            System.out.println(j + "단--------------------------");
            for(int k = 1; k < 10; k++){
                System.out.println(j + " * " + k + " = " + j*k);
            }
        }
        for(int i = 1; i < 10; i++){
            for(int l = 1; l < 10; l++){
                System.out.printf("%3d * %3d = %3d  ", i, l, l*i);
            }
            System.out.println();
        }
    }
}
