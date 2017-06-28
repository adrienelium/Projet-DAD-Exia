/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controller;

import java.io.Serializable;

/**
 *
 * @author Michael Jach
 */
public class TripletMessage implements Serializable {
    
    public String nomUser;
    public String nomFichier;
    public String cleFichier;
    public String messFichier;
    
    public TripletMessage(String username, String nomFichier, String cleFichier, String messFichier){
        this.nomUser = username;
        this.nomFichier = nomFichier;
        this.cleFichier = cleFichier;
        this.messFichier = messFichier;
    }
    
}