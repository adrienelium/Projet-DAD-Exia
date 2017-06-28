/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controller;

import java.util.ArrayList;
import java.util.List;
import javax.annotation.Resource;
import javax.inject.Inject;
import javax.jms.JMSConnectionFactory;
import javax.jms.JMSContext;
import javax.jms.MessageProducer;
import javax.jms.ObjectMessage;
import javax.jms.Queue;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;

/**
 *
 * @author Michael Jach
 */
@WebService(serviceName = "DecryptWebService")
public class DecryptWebService {  
    
    @Resource(mappedName = "mydes")
    private Queue mydes;
    
    @Inject
    @JMSConnectionFactory("java:comp/DefaultJMSConnectionFactory")
    private JMSContext context;
    
       
    
    @WebMethod(operationName = "methodeDecryptage")
    public String decryptFile(
            @WebParam(name = "decryptFile") String txt, 
            @WebParam(name = "nameFile") String name, 
            @WebParam(name = "keyDecriptFile") String keyDecript) {
        
        
        
        
        if(txt != null && name != null && keyDecript != null){
            String[] toppings = new String[3];
            toppings[0] = txt;
            toppings[1] = name;
            toppings[2] = keyDecript; 

            TripletMessage triplet = new TripletMessage(name, keyDecript, txt);
            triplet.startConcat();
            
            context.createProducer().send(mydes, triplet.startConcat());

            return "Message send au serveur :\n " 
                    + "Texte du document : " + txt + "\n"
                    + "Nom du document   :" + name + "\n"
                    + "Clef du docuement :" + keyDecript;
            
        }else{
            return "Erreur lors de l'envoi du message au serveur. Des informations sont manquantes.";
        }        
    }
}