package book_management.view;

import book_management.domain.Book;
import book_management.repository.BookRepository;
import book_management.repository.BookRepository.Choice;

import javax.swing.*;
import java.awt.*;
import java.sql.SQLException;

public class BookInsertPan extends JPanel {
    private final JTextField isbn = new JTextField();
    private final JTextField title = new JTextField();
    private final JTextField author = new JTextField();
    private final JTextField price = new JTextField();
    private final JTextField inventory = new JTextField("10");
    private final JComboBox<Choice> category = new JComboBox<>();
    private final JComboBox<Choice> publisher = new JComboBox<>();
    private final JLabel status = new JLabel();
    private final JButton save = new JButton();
    private final boolean editing;

    public BookInsertPan(BookRepository repository, Runnable refreshBooks) throws SQLException {
        this(repository, refreshBooks, false);
    }

    BookInsertPan(BookRepository repository, Runnable refreshBooks, boolean editing) throws SQLException {
        this.editing = editing;
        isbn.setEditable(!editing);
        status.setText(editing ? "표에서 수정할 도서를 선택하세요." : "도서번호는 수업에서 사용하는 숫자로 입력하세요.");
        setLayout(new BorderLayout(0, 8));
        setBorder(BorderFactory.createEmptyBorder(12, 16, 12, 16));
        JPanel form = new JPanel(new GridLayout(4, 4, 20, 2));
        addField(form, "도서번호", isbn);
        addField(form, "도서명", title);
        addField(form, "저자명", author);
        addField(form, "가격", price);
        addField(form, "재고량", inventory);
        addField(form, "카테고리", category);
        addField(form, "출판사", publisher);
        form.add(new JLabel());
        form.add(new JLabel());
        repository.categories().forEach(category::addItem);
        repository.publishers().forEach(publisher::addItem);

        save.setText(editing ? "도서수정" : "도서추가");
        save.setEnabled(!editing && category.getItemCount() > 0 && publisher.getItemCount() > 0);
        save.addActionListener(event -> register(repository, refreshBooks));
        JPanel footer = new JPanel(new BorderLayout());
        footer.add(status, BorderLayout.CENTER);
        JPanel buttons = new JPanel(new FlowLayout(FlowLayout.RIGHT));
        buttons.add(save);
        footer.add(buttons, BorderLayout.EAST);
        add(form, BorderLayout.NORTH);
        add(footer, BorderLayout.SOUTH);
    }

    void showBook(Book book) {
        isbn.setText(book == null ? "" : Integer.toString(book.getIsbn()));
        title.setText(book == null ? "" : book.getName());
        author.setText(book == null ? "" : book.getAuthor());
        price.setText(book == null ? "" : Integer.toString(book.getPrice()));
        inventory.setText(book == null ? "" : Integer.toString(book.getInventory()));
        selectChoice(category, book == null ? 0 : book.getCategoryId());
        selectChoice(publisher, book == null ? 0 : book.getPublishId());
        save.setEnabled(book != null && category.getItemCount() > 0 && publisher.getItemCount() > 0);
        status.setText(book == null ? "표에서 수정할 도서를 선택하세요." : "수정할 값을 입력하세요.");
    }

    private void selectChoice(JComboBox<Choice> combo, int id) {
        combo.setSelectedIndex(-1);
        for (int i = 0; i < combo.getItemCount(); i++) {
            if (combo.getItemAt(i).id() == id) {
                combo.setSelectedIndex(i);
                return;
            }
        }
    }

    private void addField(JPanel form, String label, JComponent input) {
        JLabel fieldLabel = new JLabel(label);
        fieldLabel.setLabelFor(input);
        form.add(fieldLabel);
        form.add(input);
    }

    private void register(BookRepository repository, Runnable refreshBooks) {
        Book book = new Book();
        book.setName(title.getText().trim());
        book.setAuthor(author.getText().trim());
        if (book.getName().isEmpty() || book.getAuthor().isEmpty()) {
            status.setText("도서명과 저자명을 입력하세요.");
            return;
        }
        try {
            book.setIsbn(Integer.parseInt(isbn.getText().trim()));
            book.setPrice(Integer.parseInt(price.getText().trim()));
            book.setInventory(Integer.parseInt(inventory.getText().trim()));
            if (book.getIsbn() <= 0 || book.getPrice() < 0 || book.getInventory() < 0) {
                throw new NumberFormatException();
            }
        } catch (NumberFormatException e) {
            status.setText("도서번호는 양수, 가격과 재고량은 0 이상 정수로 입력하세요.");
            return;
        }
        Choice selectedCategory = (Choice) category.getSelectedItem();
        Choice selectedPublisher = (Choice) publisher.getSelectedItem();
        if (selectedCategory == null || selectedPublisher == null) {
            status.setText("분류와 출판사를 선택하세요.");
            return;
        }
        String action = editing ? "수정" : "등록";
        try {
            if (editing) {
                book.setCategoryId(selectedCategory.id());
                book.setPublishId(selectedPublisher.id());
                repository.update(book);
            } else {
                repository.insert(book, selectedCategory, selectedPublisher);
            }
        } catch (SQLException e) {
            if ("02000".equals(e.getSQLState())) {
                status.setText("수정할 도서를 찾을 수 없습니다.");
            } else {
                status.setText(e.getErrorCode() == 1 ? "이미 등록된 도서번호입니다." : "도서 " + action + "에 실패했습니다.");
            }
            return;
        }
        if (!editing) {
            isbn.setText("");
            title.setText("");
            author.setText("");
            price.setText("");
            inventory.setText("10");
            isbn.requestFocusInWindow();
        }
        try {
            refreshBooks.run();
            status.setText(action + " 완료: " + book.getName());
        } catch (RuntimeException e) {
            status.setText(action + " 완료. 도서 목록을 불러오지 못했습니다.");
        }
    }
}
