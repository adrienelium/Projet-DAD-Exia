/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.middleware.calculTauxConfiance;

import javax.ejb.ActivationConfigProperty;
import javax.ejb.MessageDriven;
import javax.jms.JMSDestinationDefinition;
import javax.jms.Message;
import javax.jms.MessageListener;

/**
 *
 * @author Michael Jach
 */
@JMSDestinationDefinition(name = "java:app/jms/loggingMessages", interfaceName = "javax.jms.Queue", resourceAdapter = "jmsra", destinationName = "loggingMessages")
@MessageDriven(activationConfig = {
    @ActivationConfigProperty(propertyName = "destinationLookup", propertyValue = "java:app/jms/loggingMessages"),
    @ActivationConfigProperty(propertyName = "destinationType", propertyValue = "javax.jms.Queue")
})
public class MDB_calculTauxConfiance implements MessageListener {
    
    public MDB_calculTauxConfiance() {
    
    }
    
    @Override
    public void onMessage(Message message) {
    }
    
}
