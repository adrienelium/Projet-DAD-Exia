/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.decrypt.tauxconfiance;

import javax.ejb.ActivationConfigProperty;
import javax.ejb.EJB;
import javax.ejb.MessageDriven;
import javax.jms.Message;
import javax.jms.MessageListener;
import com.store.jpa.ConnectDB;
import com.store.jpa.Mot;
import controller.TripletMessage;
import java.util.List;
import javax.jms.ObjectMessage;
import com.store.jpa.ConnexionBDDSql;
import java.sql.Connection;

/**
 *
 * @author Michael Jach
 */
@MessageDriven(activationConfig = {
    @ActivationConfigProperty(propertyName = "destinationLookup", propertyValue = "mydes"),
    @ActivationConfigProperty(propertyName = "destinationType", propertyValue = "javax.jms.Queue")
})
public class CAM implements MessageListener {
    @EJB private TraitementTauxConfiance taux;
    //private ConnectDB connexionDB;
    private List<String> listeMotsDeLaBDD;
    
    public CAM() {
        System.out.println("Init de CAM");
        
        //this.connexionDB = new ConnectDB();
        //EntityManager em = this.connexionDB.getEm();
        //this.listeMotsDeLaBDD = this.connexionDB.GetListeMot();
        
    }
    
    
    public String convertBinaryToChar(String info, int nbBitPerCharacters){
        int foo = 0;
        long charCode;
        String stringConvertie = "";
        String [] binaryChar = info.split("(?<=\\G.{"+nbBitPerCharacters+"})");
                
        
        for(int i = 0; i < binaryChar.length; i++){
            charCode = Long.parseLong(binaryChar[i], 2);
            stringConvertie += new Character((char)charCode).toString();
        }
        return stringConvertie;
    }
    
    
    
    @Override
    public void onMessage(Message message) {
        String messageFichierDecrypte;
        TripletMessage triplet;
        
        try {
            ObjectMessage msg = (ObjectMessage) message;
            triplet = (TripletMessage) msg.getObject();
            System.out.println("------------------------");
            System.out.println("Reception d'un message");
            System.out.println("Nom Fichier: " + triplet.nomFichier);
            System.out.println("Contenu Fichier: " + triplet.messFichier);
            System.out.println("User: " + triplet.nomUser);
            System.out.println("Keye : " + triplet.cleFichier);
            
            try{
                messageFichierDecrypte = convertBinaryToChar(triplet.messFichier, 8);
            }catch(Exception ex){
                messageFichierDecrypte = triplet.messFichier;
            }
            System.out.println("Message contenu dans le fichier décrypté : \" " + messageFichierDecrypte + "\"");
            
            
            
            System.out.println(" Mot de la base de donnée : ");
            //this.connexionDB.GetListeMot("abandon");
            
            
            //System.out.println(listeMotsDeLaBDD);
            
            
            
            
            System.out.println("------------------------");
        }
        catch (Exception ex) {
            ex.printStackTrace();
            return;
        }

        
        
        
        try {
            System.out.println("----- MESSAGE BEAN: Message reçu dans calculTauxConfiance -----");
            
            // Etape 1 ------- Calcul du taux de confiance
            Double tauxConfiance = taux.Traitement(messageFichierDecrypte);
            System.out.println("Taux de confiance du fichier décrypté : " + tauxConfiance + " %");
            
            // Etape 2 ------- Recherche de l'adresse email
            if (tauxConfiance > 10.0){
                System.out.println("Recherche de l'adresse email dans le fichier décrypté...");
                TraitementRecherchePattern email = new TraitementRecherchePattern();
                String[] listeEmail = email.Traitement(messageFichierDecrypte);
                
                
                //Traitement à faire ici ...
                if ( listeEmail.length != 0 ){
                    //Je dois me connecter au SOAP du WCF pour lui indiquer que j'ai trouvée une adresse email
                }
                
            }   
            
            System.out.println("---------------------------------------------------------------");
            
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
    
}
