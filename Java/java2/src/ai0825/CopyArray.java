package ai0825;

public class CopyArray {
    public static void main(String[] args) {
        String[] foodArr = {"라면", "김밥", "떡볶이", "순대", "튀김"};
        String[] newArr = foodArr;

        foodArr[1] = "만두";
        newArr[3] = "오뎅";

        System.out.println("foodArr : ");
        for(String data : foodArr) {
            System.out.print(data + " ");
        }
        System.out.println();

        System.out.println("newArr : ");
        for(String data : newArr) {
            System.out.print(data + " ");
        }
        System.out.println();
    }
}
