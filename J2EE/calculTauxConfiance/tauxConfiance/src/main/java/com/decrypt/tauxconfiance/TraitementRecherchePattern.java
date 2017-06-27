/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.decrypt.tauxconfiance;

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
    public String[] traitement(String clearText) {
        List<String> output = new ArrayList<>();
        
        // Traitement a faire ici ...
	EmailValidator(clearText);
        
        String[] stockArr = new String[output.size()];
        System.out.println("Taille de l'array retourné pour l'email : " + output.toArray(stockArr).length);
        return output.toArray(stockArr);
    }
    
    
    public String EmailValidator(String clearText) {
        Matcher m = p.matcher(clearText);
        while (m.find())
        {
            System.out.println(m.group());
        }
             
        return m.group();
    }
    
}
