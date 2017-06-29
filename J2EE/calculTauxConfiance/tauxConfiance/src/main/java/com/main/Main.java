package com.main;

import com.store.jpa.Mot;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

/**
 *
 * @author Matthew
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