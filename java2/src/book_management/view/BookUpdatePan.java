package book_management.view;

import book_management.domain.Book;
import book_management.repository.BookRepository;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.sql.SQLException;
import java.util.List;

public class BookUpdatePan extends JPanel {
    private final String[] tableHeader = {"도서번호", "도서명", "저자명", "가격", "재고량", "카테고리", "출판사"};
    private final DefaultTableModel model = new DefaultTableModel(tableHeader, 0) {
        @Override
        public boolean isCellEditable(int row, int column) {
            return false;
        }
    };
    private final JTable table = new JTable(model);
    private final BookInsertPan editor;
    private List<Book> bookList = List.of();

    public BookUpdatePan(BookRepository repository, Runnable refreshBooks) throws SQLException {
        super(new BorderLayout());
        editor = new BookInsertPan(repository, refreshBooks, true);
        table.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        table.setFillsViewportHeight(true);
        table.setRowHeight(24);
        JLabel hint = new JLabel("도서를 삭제하려면 표에서 해당 행을 우클릭하세요.");
        hint.setBorder(BorderFactory.createEmptyBorder(6, 8, 6, 8));
        add(hint, BorderLayout.NORTH);
        add(new JScrollPane(table), BorderLayout.CENTER);
        add(editor, BorderLayout.SOUTH);

        JPopupMenu menu = new JPopupMenu();
        JMenuItem delete = new JMenuItem("도서 삭제");
        delete.addActionListener(event -> deleteSelectedBook(repository, refreshBooks));
        menu.add(delete);
        table.addMouseListener(new MouseAdapter() {
            @Override
            public void mousePressed(MouseEvent event) {
                showMenu(event);
            }

            @Override
            public void mouseReleased(MouseEvent event) {
                showMenu(event);
            }

            private void showMenu(MouseEvent event) {
                if (event.isPopupTrigger()) {
                    int row = table.rowAtPoint(event.getPoint());
                    if (row >= 0) {
                        table.setRowSelectionInterval(row, row);
                        menu.show(table, event.getX(), event.getY());
                    }
                }
            }
        });

        table.getSelectionModel().addListSelectionListener(event -> {
            if (!event.getValueIsAdjusting()) {
                showSelection();
            }
        });
        showSelection();
    }

    public void setBooks(List<Book> updatedBooks) {
        Book selected = selectedBook();
        table.clearSelection();
        bookList = List.copyOf(updatedBooks);
        model.setRowCount(0);
        int selectedRow = -1;
        for (int i = 0; i < bookList.size(); i++) {
            Book book = bookList.get(i);
            model.addRow(new Object[]{book.getIsbn(), book.getName(), book.getAuthor(), book.getPrice(),
                    book.getInventory(), book.getCategory_name(), book.getPublish_name()});
            if (selected != null && selected.getIsbn() == book.getIsbn()) {
                selectedRow = i;
            }
        }
        if (selectedRow >= 0) {
            int viewRow = table.convertRowIndexToView(selectedRow);
            table.setRowSelectionInterval(viewRow, viewRow);
        }
        showSelection();
    }

    private Book selectedBook() {
        int viewRow = table.getSelectedRow();
        return viewRow < 0 ? null : bookList.get(table.convertRowIndexToModel(viewRow));
    }

    private void showSelection() {
        editor.showBook(selectedBook());
    }

    private void deleteSelectedBook(BookRepository repository, Runnable refreshBooks) {
        Book book = selectedBook();
        if (book == null || JOptionPane.showConfirmDialog(this, book.getName() + "을(를) 삭제할까요?",
                "도서 삭제", JOptionPane.YES_NO_OPTION) != JOptionPane.YES_OPTION) {
            return;
        }

        boolean deleted;
        try {
            deleted = repository.delete(book.getIsbn());
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(this, "도서를 삭제하지 못했습니다.");
            return;
        }

        try {
            refreshBooks.run();
        } catch (RuntimeException e) {
            JOptionPane.showMessageDialog(this, "목록을 갱신하지 못했습니다. 탭을 다시 열어 확인하세요.");
            return;
        }
        if (!deleted) {
            JOptionPane.showMessageDialog(this, "이미 삭제됐거나 도서를 찾을 수 없습니다.");
        }
    }
}
