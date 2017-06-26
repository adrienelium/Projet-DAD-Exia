/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controller;

import javax.inject.Named;
import javax.enterprise.context.SessionScoped;
import java.io.Serializable;
import javax.annotation.Resource;
import javax.inject.Inject;
import javax.jms.JMSConnectionFactory;
import javax.jms.JMSContext;
import javax.jms.Queue;

/**
 *
 * @author Matthew
 */
@Named(value = "sessionController")
@SessionScoped
public class SessionController implements Serializable {

    @Resource(mappedName = "jms/Queue")
    private Queue queue;

    @Inject
    @JMSConnectionFactory("java:comp/DefaultJMSConnectionFactory")
    private JMSContext context;
    private String name;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
    

   
    public SessionController() {
    }

    private void sendJMSMessageToQueue(String messageData) {
        context.createProducer().send(queue, messageData);
    }
    
    public void send(){
        this.sendJMSMessageToQueue("hello" + this.name);
    }
    
}
