/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package decryptedFiles;

import javax.ejb.ActivationConfigProperty;
import javax.ejb.MessageDriven;
import javax.jms.Message;
import javax.jms.MessageListener;
import javax.jms.TextMessage;

/**
 *
 * @author Michael Jach
 */
@MessageDriven(activationConfig = {
    @ActivationConfigProperty(propertyName = "destinationLookup", propertyValue = "mydes"),
    @ActivationConfigProperty(propertyName = "destinationType", propertyValue = "javax.jms.Queue")
})
public class ReceivedMessageBean implements MessageListener {
    //private String consumerName;

    
    public ReceivedMessageBean() {
        //this.consumerName = consumerName;
    }
    
    
    @Override
    public void onMessage(Message message) {
        TextMessage textMessage = (TextMessage)message;
       
        try {
            if(textMessage != null){
                System.out.println("MESSAGE BEAN: Message reçu: " + textMessage.getText());
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
        
    }
    
    
}
