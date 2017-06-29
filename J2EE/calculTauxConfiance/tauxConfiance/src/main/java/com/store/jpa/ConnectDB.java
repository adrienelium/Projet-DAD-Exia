/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.store.jpa;

import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;


/**
 *
 * @author Michael Jach
 */
public class ConnectDB {
    private EntityManager em;

    
    public EntityManager getEm() {
        return em;
    }

    
    public ConnectDB(){
        EntityManagerFactory emf= Persistence.createEntityManagerFactory("PU");
        this.em= emf.createEntityManager();
    }
    
    public Boolean GetListeMot(String txt){
        this.em.getTransaction().begin();
        /*
        List<Mot> liste_mot= this.em.createNamedQuery("Mot.findAll").getResultList();
        
        if(liste_mot.isEmpty()==false){
                System.out.println("Mot de la base de donnée :" + liste_mot.get(0).getMot());
        }
             
        return liste_mot;
        */ 
        
        
        List<Mot> liste_mot= this.em.createNamedQuery("Mot.findByMot").setParameter("mot", txt).getResultList();
        
        System.out.println("LA LISTE DES MOTS TROUVEES");
        System.out.println(liste_mot);
        
        if(!liste_mot.isEmpty()){
                System.out.println("Le mot à été trouvé dans la base de données : " + liste_mot.get(0).getMot());
                return true;
        }
        System.out.println("Aucun mot trouvé dans la base de données.");
        return false;
    }
    
}
