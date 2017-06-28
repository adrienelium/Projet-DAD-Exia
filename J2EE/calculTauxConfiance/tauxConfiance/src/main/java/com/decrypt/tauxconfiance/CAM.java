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
import javax.jms.TextMessage;
import com.decrypt.tauxconfiance.TraitementTauxConfiance;
import controller.TripletMessage;
import java.math.BigInteger;
import java.util.Arrays;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.jms.JMSException;
import javax.jms.ObjectMessage;

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
    
    
    public CAM() {
        System.out.println("Init de CAM");
    }
    
    
    public String convertBinaryToChar(String info){
        
        int foo = Integer.parseInt(info);
        System.out.println("----");
        System.out.println(foo);
        System.out.println("----");
        
        long charCode = Long.parseLong(info, 2);
        String str = new Character((char)charCode).toString();
        return str;
    }
    
    
    
    @Override
    public void onMessage(Message message) {
        
        TripletMessage triplet;
        try {
            ObjectMessage msg = (ObjectMessage) message;
            triplet = (TripletMessage) msg.getObject();
            System.out.println("------------------------");
            System.out.println("Reception d'un message");
            System.out.println("Nom Fichier: " + triplet.nomFichier);
            System.out.println("Contenu Fichier: " + triplet.messFichier);
            System.out.println("User: " + triplet.nomUser);
            System.out.println("Key : " + triplet.cleFichier);
            
            /*
            int charCode = Integer.parseInt(triplet.messFichier, 2);
            String str = new Character((char)charCode).toString();
            System.out.println( str );
            */            
            
            /*
            try{
            
                int charCode = Integer.parseInt(triplet.messFichier, 2);
                String str = new Character((char)charCode).toString();
                System.out.println( str );
            */
            /*
            }catch(Exception ex){
                System.out.println("Le message n'est pas en binaire.");
            }
            */
            
            //String binaire = "101110111110011110110001010110100001000001100100001110101111011101101";
            String binaire = "10111011";
            //convertBinaryToString("1011");
            
            
            System.out.println("Retour fonction : " + convertBinaryToChar(binaire));
            System.out.println("------------------------");
        }
        catch (Exception ex) {
            ex.printStackTrace();
            return;
        }

        try {
            System.out.println("MESSAGE BEAN: Message reçu dans calculTauxConfiance.");

            // Etape 1 -------
            //Double tauxConfiance(textMessage.getText());
            String messageDecryt = triplet.messFichier;

            Double tauxConfiance = taux.Traitement(messageDecryt);
            System.out.println("Taux Confiance calculé : " + tauxConfiance + " %");


            if (tauxConfiance > 10.0){
                System.out.println("Je rentre ici");
                TraitementRecherchePattern email = new TraitementRecherchePattern();
                email.Traitement(messageDecryt);

                //int[] myIntArray = new int[3];
                //String adresseEmail = email.traitement(textMessage.getText());
            }   
            
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
    
}
