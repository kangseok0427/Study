package ai0825;

public class RandomWords {
    public static void main(String[] args) {
        String[] words = {"1퍼센트의 가능성, 그것이 나의 길이다."
        , "죽고자 하면 살 것이고, 살고자 하면 죽을 것이다. - 이순신 제독"
        , "너 자신을 알라. - 소크라테스"
        , "살아있는 한 희망은 있다. - 키케로"
        , "인생은 가까이서 보면 비극이지만, 멀리서 보면 희극이다. - 헤라클레스"
        , "인생은 한 번뿐이다. 그러므로 즐겨라. - 에라스무스"
        , "인생은 즐거움과 고통이 교차하는 것이다. - 괴테"
        , "인생은 짧다. 그러므로 사랑하라. - 세네카"
        , "인생은 선택의 연속이다. - 알베르트 아인슈타인"
        };
        int randomIndex = (int)(Math.random() * words.length);
        System.out.println("오늘의 명언 : " + words[randomIndex]);
    }
}
