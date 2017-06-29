/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package bean;

import entity.Mot;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

/**
 *
 * @author Matthew
 */
@Stateless
public class MotFacade extends AbstractFacade<Mot> {

    @PersistenceContext(unitName = "JSFWithEntityClassPU")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    public MotFacade() {
        super(Mot.class);
    }
    
}
