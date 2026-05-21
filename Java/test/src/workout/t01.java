import java.util.Scanner;

public class t01 {

    // 두 수와 연산자를 받아서 계산 결과를 반환하는 메서드
    public static double calculate(double num1, double num2, char operator) {
        switch (operator) {
            case '+': return num1 + num2;
            case '-': return num1 - num2;
            case '*': return num1 * num2;
            case '/':
                if (num2 == 0) {
                    System.out.println("  [오류] 0으로 나눌 수 없습니다!");
                    return Double.NaN; // Not a Number 반환
                }
                return num1 / num2;
            default:
                System.out.println("  [오류] 올바른 연산자가 아닙니다. (+, -, *, / 만 가능)");
                return Double.NaN;
        }
    }

    // 구분선 출력 메서드 (UI 꾸미기용)
    public static void printLine() {
        System.out.println("  ================================");
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String again = "y";

        System.out.println();
        System.out.println("  ================================");
        System.out.println("       ★  Java 계산기  ★");
        System.out.println("  ================================");

        // 계속 계산할지 여부를 묻는 반복문
        while (again.equals("y") || again.equals("Y")) {

            System.out.println();
            System.out.print("  첫 번째 숫자 입력: ");
            double num1 = scanner.nextDouble();

            System.out.print("  연산자 입력 (+, -, *, /): ");
            char operator = scanner.next().charAt(0);

            System.out.print("  두 번째 숫자 입력: ");
            double num2 = scanner.nextDouble();

            printLine();

            double result = calculate(num1, num2, operator);

            // 결과가 유효할 때만 출력
            if (!Double.isNaN(result)) {
                // 결과가 정수면 정수로, 소수면 소수로 출력
                if (result == (long) result) {
                    System.out.printf("  결과: %.0f %c %.0f = %.0f%n", num1, operator, num2, result);
                } else {
                    System.out.printf("  결과: %.2f %c %.2f = %.2f%n", num1, operator, num2, result);
                }
            }

            printLine();

            System.out.print("\n  계속 계산하시겠습니까? (y/n): ");
            again = scanner.next();
        }

        System.out.println();
        System.out.println("  ================================");
        System.out.println("       계산기를 종료합니다.");
        System.out.println("  ================================");
        System.out.println();

        scanner.close();
    }
}