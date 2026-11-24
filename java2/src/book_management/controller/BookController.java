package book_management.controller;

import book_management.domain.Book;
import book_management.repository.BookRepository;
import book_management.view.BookInsertPan;
import book_management.view.BookSearchPan;
import book_management.view.BookUpdatePan;
import book_management.view.center.SetFrame;

import javax.swing.*;
import java.sql.SQLException;
import java.util.ArrayList;

public class BookController extends JFrame {
    private final JTabbedPane tabbedPane = new JTabbedPane(JTabbedPane.TOP);
    private final BookRepository repository = new BookRepository();
    private final BookSearchPan searchPan = new BookSearchPan();
    private BookUpdatePan editPanel;

    public BookController() {
        ArrayList<Book> bookList = repository.select(searchPan.getSearchWord(), searchPan.getCombo().getSelectedIndex());
        searchPan.setBookList(bookList);
        searchPan.initView();
        tabbedPane.addTab("도서 검색", searchPan);
        try {
            BookInsertPan insertPan = new BookInsertPan(repository, this::refreshCurrentTab);
            editPanel = new BookUpdatePan(repository, this::refreshCurrentTab);
            editPanel.setBooks(bookList);
            tabbedPane.addTab("도서 추가", insertPan);
            tabbedPane.addTab("수정 및 삭제", editPanel);
            tabbedPane.setSelectedComponent(editPanel);
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(this, "분류나 출판사 목록을 불러오지 못했습니다.");
        }
        tabbedPane.addChangeListener(event -> {
            try {
                refreshCurrentTab();
            } catch (RuntimeException e) {
                JOptionPane.showMessageDialog(this, "도서 목록을 불러오지 못했습니다.");
            }
        });
        add(tabbedPane);

        SetFrame.setFrame(this, "도서관리 시스템", 700, 600);
    }

    private void refreshCurrentTab() {
        if (tabbedPane.getSelectedComponent() == searchPan) {
            searchPan.setBookList(repository.select(searchPan.getSearchWord(), searchPan.getCombo().getSelectedIndex()));
            searchPan.putSearchResult();
        } else if (editPanel != null && tabbedPane.getSelectedComponent() == editPanel) {
            editPanel.setBooks(repository.select("", 0));
        }
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(BookController::new);
    }
}
