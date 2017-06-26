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
 * @author Michael Jach
 */
@Named(value = "helloController")
@SessionScoped
public class HelloController implements Serializable {

    @Resource(mappedName = "mydes")
    private Queue mydes;

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

    
    
    
    public HelloController() {
    }

    private void sendJMSMessageToMydes(String messageData) {
        context.createProducer().send(mydes, messageData);
    }
    
    public void send(){
        this.sendJMSMessageToMydes(this.name);
    }
    
}
