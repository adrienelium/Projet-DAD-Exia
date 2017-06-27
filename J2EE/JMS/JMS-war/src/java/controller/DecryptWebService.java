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
        
        String[] toppings = new String[3];
        toppings[0] = txt;
        toppings[1] = name;
        toppings[2] = keyDecript; 
        
        context.createProducer().send(mydes, toppings);
        //context.createProducer().send(mydes, txt);
        //context.createProducer().send(mydes, name);
        //context.createProducer().send(mydes, keyDecript);
        
        return "Message envoyé au serveur : \n " 
                + "Texte du document : " + txt + "\n"
                + "Nom du document   :" + name + "\n"
                + "Clef du docuement :" + keyDecript;
    }
}