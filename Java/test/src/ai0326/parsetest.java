package ai0326;

public class parsetest {
    public static void main(String[] args) {
        String n1 = "2026";
        String n2 = "3.14";

        int pn1 = Integer.parseInt(n1);
        double pn2 = Double.parseDouble(n2);

        System.out.println("변환된 정수값 " +pn1+"\n변환된 실수값"+pn2);
    }
}
