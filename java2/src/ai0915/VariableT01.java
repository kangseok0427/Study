package ai0915;

public class VariableT01 {

    static int a = 100;
    int b = 500;

    static void method1(){
        int a = 300;
        int b = 7000;
        System.out.println("지역 변수 a의 저장된 값 : " + a);
        System.out.println("전역 변수(필드) a를 method1()에서 사용하고 싶을 때 : " + VariableT01.a);
        VariableT01 vt1 = new VariableT01();
        System.out.println("전역 변수 b를 method1()에서 사용하고 싶을 때 : " + vt1.b);

    }

    static void method2(){
        a += 20;
        System.out.println("전역 변수(필드) a의 저장된 값 : " + a);
    }

    public static void main(String[] args){
        method1();
        method2();
    }
}
