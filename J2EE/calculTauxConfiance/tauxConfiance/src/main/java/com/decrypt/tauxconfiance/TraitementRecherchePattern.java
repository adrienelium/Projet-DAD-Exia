/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.decrypt.tauxconfiance;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 *
 * @author Michael Jach
 */
public class TraitementRecherchePattern implements ITraitement<String[]>{
    private Pattern p = Pattern.compile("[a-z0-9._-]+@[a-z0-9._-]{2,}\\.[a-z]{2,4}", Pattern.MULTILINE);
    
    
    @Override
    public String[] Traitement(String clearText) {
        List<String> output = new ArrayList<>();
        
        // Traitement a faire ici ...
	String[] tab = EmailValidator(clearText);
        
        String[] stockArr = new String[output.size()];
        
        for(int i = 0; i < tab.length; i++){
            System.out.println("Adresse email trouvée " + (i+1) + ": " + tab[i]);
        }
        
        return output.toArray(stockArr);
    }
    
    
    public String[] EmailValidator(String clearText) {
        Matcher m = p.matcher(clearText);
        ArrayList<String> emailsArray = new ArrayList<String>();
        while (m.find())
        {
            emailsArray.add( m.group() );
            System.out.println("test : " + m.group());
        }
        
        String[] stockArr = new String[emailsArray.size()];
        stockArr = emailsArray.toArray(stockArr);

        return stockArr;
    }
    
   
    
}