/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.test;

import com.store.jpa.ConnectDB;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Michael Jach
 */
public class TestUnitaire {
    

    @Test
    public void hello() {
    
    ConnectDB db = new ConnectDB();
    
    db.GetListeMot("maison");
    
    
    }
}
