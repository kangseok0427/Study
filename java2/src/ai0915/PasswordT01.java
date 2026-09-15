package ai0915;

import java.util.Scanner;

public class PasswordT01 {

    public static void main(String[] args){
        Scanner scanner = new Scanner(System.in);

        while(true){
            System.out.print("새로운 비밀번호를 입력하세요 : ");
            String password = scanner.nextLine();
            boolean correct = true;

            if(password.length() < 8)
                correct = false;

            for(int i = 0; i < password.length(); i++){
                char ch = password.charAt(i);

                if(!((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')
                        || (ch >= '가' && ch <= '힣') || (ch >= 'ㄱ' && ch <= 'ㅎ')
                        || (ch >= 'ㅏ' && ch <= 'ㅣ'))){
                    correct = false;
                    break;
                }
            }

            if(correct){
                System.out.println("Good~ 비밀번호가 올바르게 생성되었어요.");
                break;
            }
            else{
                System.out.println("오류! 비밀번호가 규칙에 맞지 않습니다.");
            }
        }

        scanner.close();
    }
}
