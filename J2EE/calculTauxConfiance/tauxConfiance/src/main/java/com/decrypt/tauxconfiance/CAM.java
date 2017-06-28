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
    
    @Override
    public void onMessage(Message message) {
        
        TripletMessage triplet;
        try {
            ObjectMessage msg = (ObjectMessage) message;
            triplet = (TripletMessage) msg.getObject();
            System.out.println("Reception d'un message");
            System.out.println("Nom Fichier: " + triplet.nomFichier);
            System.out.println("Contenu Fichier: " + triplet.messFichier);
            System.out.println("User: " + triplet.nomUser);
            System.out.println("Key : " + triplet.cleFichier);
        }
        catch (Exception ex) {
            ex.printStackTrace();
            return;
        }

        try {
            if(triplet != null){
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
                
                
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
    
}
