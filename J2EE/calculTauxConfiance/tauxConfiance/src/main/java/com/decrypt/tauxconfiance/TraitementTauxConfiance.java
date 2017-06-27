/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.decrypt.tauxconfiance;

import java.util.ArrayList;
import java.util.List;
import javax.ejb.Stateless;
import javax.ejb.LocalBean;

/**
 *
 * @author Michael Jach
 */
@Stateless
@LocalBean
public class TraitementTauxConfiance implements ITraitement<Double> {
    private int nombreDeMots = 0, nbLettresMinimale = 2, nbLettresMaximale = 20, nombreDeMotsMaxAAnalyserDansLeFichier = 100;
    private List<String> bdd =  new ArrayList<String>() ;

    // Add business logic below. (Right-click in editor and choose
    // "Insert Code > Add Business Method")

    public TraitementTauxConfiance() {
        //Connexion à la base de données
        this.bdd.add("test1");
        this.bdd.add("test2");
        this.bdd.add("test3");
        
        
        this.nombreDeMots = 0;
        this.nbLettresMinimale = 2;
        this.nbLettresMaximale = 20;
        this.nombreDeMotsMaxAAnalyserDansLeFichier = 100;
    }
    

    @Override
    public Double traitement(String clearText) {
        ArrayList<String> wordArrayList = new ArrayList<String>();
        Double taux = 0.0;
       
        for(String word : clearText.split(" ")) {
            ++nombreDeMots;
            
            if(nombreDeMots <= this.nombreDeMotsMaxAAnalyserDansLeFichier){
                
                if(isValidWord(word)){
                    // # Etape 1 :::: Si le mot et considéré comme "Valide" (Mot Francais)
                    
                    if(compareStringToBDD(word, this.bdd)){
                        // # Etape 2 :::: Si le mot est dans la BDD
                        System.out.println("Mot présent dans la base de données : " + word);
                        wordArrayList.add(word);
                    }
                }
            }
        }
        
        
        if(!wordArrayList.isEmpty() && nombreDeMots != 0){
            taux = (double)(wordArrayList.size() / nombreDeMots)*100;
            System.out.println("Je rentre ici !!" + taux);
        }
        
        return taux;
    }
    
  
    
    
    
    /*
    * Fonction pour tester si le mot correspond aux critères
    */
    public Boolean compareStringToBDD(String motFichier, List<String> bdd){
        motFichier = motFichier.toLowerCase();
        
        //Itère sur les mots dans la base de données
        for (String motBdd : bdd) {
            if (motFichier.equals(motBdd)){
                System.out.println("Correspondance du mot établie dans la base de données : " + motFichier);
                return true;
            }
        }
        return false;
    }
    
    
    

    /*
    * Fonction pour tester si le mot correspond aux critères
    */
    public Boolean isValidWord(String mot){
        int nombreDelettres = 0;
        for (int i=0; i<mot.length(); i++) {
            if (mot.charAt(i) != ' ') {
               ++nombreDelettres;
            }
        }
        
        if( nombreDelettres < this.nbLettresMaximale && nombreDelettres > this.nbLettresMinimale  ){  
            return true;
        }else{
            return false;
        } 
    }
    
    
}
