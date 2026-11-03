package ai1103;

import center.SetFrame;

import javax.swing.*;
import javax.swing.event.DocumentEvent;
import javax.swing.event.DocumentListener;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

public class MenuTest extends JFrame {
    JTextArea textArea = new JTextArea();
    JLabel countLabel = new JLabel("글자 수: 0");
    File currentFile;

    public MenuTest(){
        setLayout(new BorderLayout());
        FileListener fileListener = new FileListener();
        BackgroundListener backgroundListener = new BackgroundListener();

        JToolBar toolBar = new JToolBar();
        toolBar.setFloatable(false);
        String iconPath = "imgs/toolbar/";

        JButton newButton = new JButton(new ImageIcon(iconPath + "new.png", "New File"));
        JButton openButton = new JButton(new ImageIcon(iconPath + "open.png", "Open"));
        JButton saveButton = new JButton(new ImageIcon(iconPath + "save.png", "Save"));
        newButton.setActionCommand("New File");
        openButton.setActionCommand("Open");
        saveButton.setActionCommand("Save");
        newButton.setToolTipText("New File");
        openButton.setToolTipText("Open");
        saveButton.setToolTipText("Save");
        newButton.addActionListener(fileListener);
        openButton.addActionListener(fileListener);
        saveButton.addActionListener(fileListener);
        toolBar.add(newButton);
        toolBar.add(openButton);
        toolBar.add(saveButton);
        toolBar.addSeparator();

        JButton whiteButton = new JButton(new ImageIcon(iconPath + "white.png", "White"));
        JButton blueButton = new JButton(new ImageIcon(iconPath + "blue.png", "Blue"));
        JButton magentaButton = new JButton(new ImageIcon(iconPath + "magenta.png", "Magenta"));
        whiteButton.setActionCommand("White");
        blueButton.setActionCommand("Blue");
        magentaButton.setActionCommand("Magenta");
        whiteButton.setToolTipText("White");
        blueButton.setToolTipText("Blue");
        magentaButton.setToolTipText("Magenta");
        whiteButton.addActionListener(backgroundListener);
        blueButton.addActionListener(backgroundListener);
        magentaButton.addActionListener(backgroundListener);
        toolBar.add(whiteButton);
        toolBar.add(blueButton);
        toolBar.add(magentaButton);
        toolBar.addSeparator();
        countLabel.setToolTipText("공백과 줄바꿈 포함");
        toolBar.add(countLabel);
        add(toolBar, BorderLayout.NORTH);

        textArea.setFont(new Font("맑은 고딕", Font.PLAIN, 16));
        textArea.setLineWrap(true);
        textArea.setWrapStyleWord(true);
        textArea.getDocument().addDocumentListener(new TextCountListener());
        JScrollPane scrollPane = new JScrollPane(textArea,
                JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED,
                JScrollPane.HORIZONTAL_SCROLLBAR_NEVER);
        add(scrollPane, BorderLayout.CENTER);

        SetFrame.setFrame(this, "간단한 메모장", 500, 500);
    }

    class FileListener implements ActionListener {
        @Override
        public void actionPerformed(ActionEvent e){
            String menu = e.getActionCommand();

            if(menu.equals("New File")){
                textArea.setText("");
                currentFile = null;
                setTitle("간단한 메모장");
            }else if(menu.equals("Open")){
                JFileChooser fileChooser = new JFileChooser(new File("."));
                if(fileChooser.showOpenDialog(MenuTest.this) == JFileChooser.APPROVE_OPTION){
                    File file = fileChooser.getSelectedFile();
                    try(FileReader reader = new FileReader(file, StandardCharsets.UTF_8)){
                        textArea.read(reader, null);
                        textArea.getDocument().addDocumentListener(new TextCountListener());
                        updateCount();
                        textArea.setCaretPosition(0);
                        currentFile = file;
                        setTitle(file.getName() + " - 간단한 메모장");
                    }catch(IOException ex){
                        JOptionPane.showMessageDialog(MenuTest.this, "파일을 읽을 수 없습니다.");
                    }
                }
            }else if(menu.equals("Save")){
                File file = currentFile;

                if(file == null){
                    JFileChooser fileChooser = new JFileChooser(new File("."));
                    if(fileChooser.showSaveDialog(MenuTest.this) != JFileChooser.APPROVE_OPTION){
                        return;
                    }
                    file = fileChooser.getSelectedFile();

                    if(file.exists()){
                        int result = JOptionPane.showConfirmDialog(MenuTest.this,
                                "같은 이름의 파일이 있습니다. 덮어쓸까요?", "저장 확인",
                                JOptionPane.YES_NO_OPTION);
                        if(result != JOptionPane.YES_OPTION){
                            return;
                        }
                    }
                }

                try(FileWriter writer = new FileWriter(file, StandardCharsets.UTF_8)){
                    textArea.write(writer);
                    currentFile = file;
                    setTitle(file.getName() + " - 간단한 메모장");
                }catch(IOException ex){
                    JOptionPane.showMessageDialog(MenuTest.this, "파일을 저장할 수 없습니다.");
                }
            }
        }
    }

    void updateCount(){
        countLabel.setText("글자 수: " + textArea.getDocument().getLength());
    }

    class TextCountListener implements DocumentListener {
        @Override
        public void insertUpdate(DocumentEvent e){
            updateCount();
        }

        @Override
        public void removeUpdate(DocumentEvent e){
            updateCount();
        }

        @Override
        public void changedUpdate(DocumentEvent e){
            updateCount();
        }
    }

    class BackgroundListener implements ActionListener {
        @Override
        public void actionPerformed(ActionEvent e){
            String color = e.getActionCommand();
            textArea.setForeground(Color.BLACK);

            if(color.equals("White")){
                textArea.setBackground(Color.WHITE);
            }else if(color.equals("Blue")){
                textArea.setBackground(Color.BLUE);
                textArea.setForeground(Color.WHITE);
            }else if(color.equals("Magenta")){
                textArea.setBackground(Color.MAGENTA);
            }
        }
    }

    public static void main(String[] args){
        new MenuTest();
    }
}
