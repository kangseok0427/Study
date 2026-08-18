public class runabs {
    public static void main(String[] args) {
        men men = new men();
        women women = new women();

        men.name = "John";
        men.weight = 70;
        men.height = 180;

        women.name = "Jane";
        women.weight = 60;
        women.height = 165;

        men.eat("apple");
        men.study();
        men.sleep(8 );

        women.eat("banana");
        women.study();
        women.sleep(8 );
    }
}
