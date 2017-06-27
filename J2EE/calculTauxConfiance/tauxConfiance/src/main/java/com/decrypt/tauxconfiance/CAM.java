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
    }
    
    @Override
    public void onMessage(Message message) {
        TextMessage textMessage = (TextMessage)message;
       
        try {
            if(textMessage != null){
                System.out.println("MESSAGE BEAN: Message reçu dans calculTauxConfiance: " + textMessage.getText());
                
                
                // Etape 1 -------
                //Double tauxConfiance(textMessage.getText());
                Double tauxConfiance = taux.traitement(textMessage.getText());
                System.out.println("Taux Confiance calculé : " + tauxConfiance);
                
                                
                if (tauxConfiance > 10.0){
                    TraitementRecherchePattern email = new TraitementRecherchePattern();
                    
                    //int[] myIntArray = new int[3];
                    //String adresseEmail = email.traitement(textMessage.getText());
                }
                
                
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
    
}
