public class Tank implements Car, Canon {
    public void move(){
        System.out.println("대포를 발사한다.");
    }
    public void fire(){
        System.out.println("탱크가 이동한다.");
    }
}
