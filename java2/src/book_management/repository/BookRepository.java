package book_management.repository;

import book_management.domain.Book;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public class BookRepository {
    ArrayList<Book> bookList;

    public record Choice(int id, String name) {
        @Override
        public String toString() {
            return name;
        }
    }

    public ArrayList<Choice> categories() throws SQLException {
        return choices("select category_id, category_name from category order by category_id");
    }

    public ArrayList<Choice> publishers() throws SQLException {
        return choices("select publish_id, publish_name from publish order by publish_id");
    }

    private ArrayList<Choice> choices(String sql) throws SQLException {
        ArrayList<Choice> choices = new ArrayList<>();
        try (Connection con = connect();
             PreparedStatement statement = con.prepareStatement(sql);
             ResultSet rows = statement.executeQuery()) {
            while (rows.next()) {
                choices.add(new Choice(rows.getInt(1), rows.getString(2)));
            }
        }
        return choices;
    }

    public void insert(Book book, Choice category, Choice publisher) throws SQLException {
        String sql = "insert into book (isbn, name, author, price, inventory, category_id, publish_id) "
                + "values (?, ?, ?, ?, ?, ?, ?)";
        try (Connection con = connect();
             PreparedStatement statement = con.prepareStatement(sql)) {
            statement.setString(1, Integer.toString(book.getIsbn()));
            statement.setString(2, book.getName());
            statement.setString(3, book.getAuthor());
            statement.setInt(4, book.getPrice());
            statement.setInt(5, book.getInventory());
            statement.setInt(6, category.id());
            statement.setInt(7, publisher.id());
            statement.executeUpdate();
        }
    }

    public void update(Book book) throws SQLException {
        String sql = "update book set name = ?, author = ?, price = ?, inventory = ?, "
                + "category_id = ?, publish_id = ? where isbn = ?";
        try (Connection con = connect(); PreparedStatement statement = con.prepareStatement(sql)) {
            statement.setString(1, book.getName());
            statement.setString(2, book.getAuthor());
            statement.setInt(3, book.getPrice());
            statement.setInt(4, book.getInventory());
            statement.setInt(5, book.getCategoryId());
            statement.setInt(6, book.getPublishId());
            statement.setString(7, Integer.toString(book.getIsbn()));
            if (statement.executeUpdate() == 0) {
                throw new SQLException("수정할 도서를 찾을 수 없습니다.", "02000");
            }
        }
    }

    public boolean delete(int isbn) throws SQLException {
        String sql = "delete from book where isbn = ?";
        try (Connection con = connect(); PreparedStatement statement = con.prepareStatement(sql)) {
            statement.setString(1, Integer.toString(isbn));
            return statement.executeUpdate() == 1;
        }
    }

    private Connection connect() throws SQLException {
        Connection con = JDBCConnector.getConnection();
        if (con == null || con.isClosed()) {
            throw new SQLException("도서 데이터베이스에 연결할 수 없습니다.");
        }
        return con;
    }

    public ArrayList<Book> select(String searchWord, int selectedIndex) {
        bookList = new ArrayList<>();
        String[] columnName = {"b.name", "p.publish_name", "b.author"};
        ResultSet rs = null;

        String sql = "select b.isbn, b.name, b.author, b.price, b.inventory, "
                + "b.category_id, b.publish_id, c.category_name, p.publish_name from book b, category c, publish p "
                + "where b.category_id = c.category_id and b.publish_id = p.publish_id "
                + "and " + columnName[selectedIndex] + " like ?";

        try (Connection con = connect();
             PreparedStatement pstmt = con.prepareStatement(sql)) {
            pstmt.setString(1, "%" + searchWord + "%");
            rs = pstmt.executeQuery();

            Book book = null;
            while (rs.next()) {
                book = new Book();
                book.setIsbn(rs.getInt("isbn"));
                book.setName(rs.getString("name"));
                book.setAuthor(rs.getString("author"));
                book.setPrice(rs.getInt("price"));
                book.setInventory(rs.getInt("inventory"));
                book.setCategoryId(rs.getInt("category_id"));
                book.setPublishId(rs.getInt("publish_id"));
                book.setCategory_name(rs.getString("category_name"));
                book.setPublish_name(rs.getString("publish_name"));
                bookList.add(book);
            }
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }

        return bookList;
    }
}
