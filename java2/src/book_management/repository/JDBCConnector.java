package book_management.repository;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class JDBCConnector {
    private static final String DRIVER_PATH = "oracle.jdbc.driver.OracleDriver";
    private static final String URL = "jdbc:oracle:thin:@localhost:1521/xe";
    private static final String USER_NAME = "c##aisoft";
    private static final String PASSWORD = "1234";
    private static Connection con;

    public static Connection getConnection(){
        try{
            Class.forName(DRIVER_PATH);

            System.out.println("JDBC Driver Class found.");
            con = DriverManager.getConnection(URL, USER_NAME, PASSWORD);

            System.out.println("Connection Succeeded.");
        }catch (ClassNotFoundException e){
            System.out.println("JDBC Driver Class not found: " + e.getMessage());
        } catch (SQLException e) {
            System.out.println("Connection failed.");
        }


        return con;
    }

    public static void main(String[] args){
        getConnection();
    }
}
