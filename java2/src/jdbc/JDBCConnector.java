package jdbc;

import java.sql.*;

public class JDBCConnector {
    private static final String DRIVER_PATH = "oracle.jdbc.driver.OracleDriver";
    private static final String URL = "jdbc:oracle:thin:@localhost:1521/xe";
    private static final String USER_NAME = "c##mkj";
    private static final String PASSWORD = "1234";

    private static Connection con;
    public static Connection getConnection(){
        try{
            Class.forName(DRIVER_PATH);
            System.out.println("driver connected");
            con = DriverManager.getConnection(URL, USER_NAME, PASSWORD);
            System.out.println("Connection Success");
        }catch(ClassNotFoundException e){
            System.out.println("driver class not found");
        }catch(SQLException e) {
            System.out.println("Connection Failed");
        }

        return con;
    }

    public static void resultSetTest(){
        String sql = "select * from 고객";
        try{
            PreparedStatement pstmt = con.prepareStatement(sql);
            ResultSet rs = pstmt.executeQuery();
            while(rs.next()){
                System.out.print(rs.getString("고객아이디") + "\t");
                System.out.print(rs.getString("고객이름") + "\t");
                System.out.print(rs.getString("직업") + "\t");
                System.out.println();
            }
        }catch (SQLException e){
            System.out.println("DB textlie not created");
        }
    }

    public static void mian(String[] args){
        getConnection();
    }
}
