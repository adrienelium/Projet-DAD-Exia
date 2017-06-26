/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controller;

import javax.annotation.Resource;
import javax.inject.Inject;
import javax.jms.JMSConnectionFactory;
import javax.jms.JMSContext;
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
    public String decryptFile(@WebParam(name = "decryptFile") String txt) {
        
        context.createProducer().send(mydes, txt);
        return "Message envoyé au serveur :" + txt;
    }
}
