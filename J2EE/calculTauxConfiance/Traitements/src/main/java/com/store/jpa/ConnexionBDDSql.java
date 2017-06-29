package com.store.jpa;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;

/**
 *
 * @author antoi
 */

public class ConnexionBDDSql {
    private Connection connection;
    
    public ConnexionBDDSql(){
         try{
            String url = "jdbc:mysql://localhost:3306/lexique";
            String user = "root";
            String passwd ="";
            this.connection = DriverManager.getConnection(url, user, passwd);
        }catch(Exception e){
            try {
                System.out.println(e.getMessage());
            } catch (Exception ex) {
                java.util.logging.Logger.getLogger(ConnexionBDDSql.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }
        
    public List<String> getListMot(){        
        List<String> arr = new ArrayList();
        
        try {
            Statement st = this.connection.createStatement();
            ResultSet listeMots = st.executeQuery("SELECT * FROM mot");
            
            while(listeMots.next()){
                arr.add(listeMots.getString( "mot" ));
            }
        } catch (Exception e) {
            System.out.println(e);
        }
        return arr;
    }
}
