/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.main;

import com.store.jpa_last.Mot;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

/**
 *
 * @author Matthew
 */
public class Main {
    
    

    /**
     * @param args the command line arguments
     */
    public void main() {
        
        EntityManagerFactory emf= Persistence.createEntityManagerFactory("PU");
    EntityManager em= emf.createEntityManager();
    
    em.getTransaction().begin();
    List<Mot> liste_mot= em.createNamedQuery("Mot.findAll").getResultList();
    
    if(liste_mot.isEmpty()==false){
      
        System.out.println(liste_mot.get(0).getMot());
    }
   
    }
    
}
