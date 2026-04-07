package ai0402;

public class t03 {
    public static void main(String[] args) {
        int ar1[] = {500, 900, 800, 3500, 700, 100};
        int ar2[] = {1800, 1400, 1800, 4000, 1500, 2000};

        int to = 0;

        System.out.println("삼각김밥 (" + ar1[1] + "원) 10개 구입");
        to -= (ar1[1] * 10);
        System.out.println("바나나맛 우유 (" + ar2[2] + "원) 2개 판매");
        to += (ar2[2] * 2);
        System.out.println("도시락 (" + ar1[3] + "원) 5개 구입");
        to -= (ar1[3] * 5);
        System.out.println("도시락 (" + ar2[3] + "원) 4개 판매");
        to += (ar2[3] * 4);
        System.out.println("콜라 (" + ar1[4] + "원) 1개 판매");
        to += ar2[4];
        System.out.println("새우깡 (" + ar1[5] + "원) 4개 판매");
        to += (ar2[5] * 4);
        System.out.println("캔커피 (" + ar1[0] + "원) 5개 판매");
        to += (ar2[0] * 5);

        System.out.println("총매출 : " + to);
    }
}
