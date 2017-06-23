using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace KeyGenerator
{
    public class KeyByte
    {
        private char[] tabAscii =
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z','A','B','C','D','E',
                'F','G','H','I','J','K','L','M','N','O','P','Q','R',
                'S','T','U','V','W','X','Y','Z','1','2','3','4','5',
                '6','7','8','9','0','!','$','#','@','-'
            };

        private int keyId = 56890265;

        public KeyByte() { }

        

        public int[] getKeyInBase()
        {
            int[] tab = new int[8];
            int compteur = keyId;

            int i = 0;
            while(compteur/tabAscii.Length != 0)
            {
                tab[i] = compteur % tabAscii.Length;
                compteur = compteur / tabAscii.Length;
                i++;
                //Debug.WriteLine(compteur);
            }

            tab[i] = compteur % tabAscii.Length;


            return tab;
        }




       
    }
}
