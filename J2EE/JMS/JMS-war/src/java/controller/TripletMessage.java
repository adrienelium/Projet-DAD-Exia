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
public class TripletMessage implements Serializable{
    
    private String nomFichier;
    private String cleFichier;
    private String messFichier;
    private String separateur;
    
    public TripletMessage(String nomFichier, String cleFichier, String messFichier){
        this.nomFichier = nomFichier;
        this.cleFichier = cleFichier;
        this.messFichier = messFichier;
        this.separateur = "<//**??:::||:::<@>:::||:::??**//>";
    }
    
    public String startConcat(){
    
        String str = this.nomFichier;
        str = str.concat(this.separateur);
        str = str.concat(this.cleFichier);
        str = str.concat(this.separateur);
        str = str.concat(this.messFichier);
        
        return str;
    }
}