/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.main;

import com.store.jpa.Mot;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

/**
 *
 * @author Michael Jach
 */
public class Main {
    
    public void main() {
        
        EntityManagerFactory emf= Persistence.createEntityManagerFactory("PU");
        EntityManager em= emf.createEntityManager();

        em.getTransaction().begin();
        List<Mot> liste_mot= em.createNamedQuery("Mot.findAll").getResultList();


        if(liste_mot.isEmpty()==false){
                int i = 0;

            for(i = 1; i <= 230000 ; i++){
                System.out.println(liste_mot.get(i).getMot());
            }

        }
   
    }
    
}