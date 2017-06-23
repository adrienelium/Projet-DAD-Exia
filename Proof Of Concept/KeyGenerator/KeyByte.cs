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

        private int keyId = 0;
        private int tabAmountValue;

        public KeyByte(int bitSize) // 32bit pour une clé de 4 caractères
        {
            tabAmountValue = bitSize/8;
        }

        public string GetKey()
        {
            double[] listdouble = inverseArray(getKeyInBase());

            keyId++;
            return string.Join("", translateString(listdouble));
        }

        private string[] translateString(double[] tab)
        {
            string[] tempTab = new string[tabAmountValue];
            for (int i = 0; i < tab.Length; i++)
            {
                int val = (int) tab[i];
                tempTab[i] = tabAscii[val].ToString();
            }

            return tempTab;
        }

        private double[] inverseArray(double[] tabKeyReverse)
        {
            double[] tempTab = new double[tabAmountValue];

            for (int i = 0; i < tabAmountValue; i++)
            {
                int index = tabAmountValue - 1 - i;
                tempTab[i] = tabKeyReverse[index];
            }

            return tempTab;
        }
        

        private double[] getKeyInBase()
        {
            double[] tab = new double[tabAmountValue];
            int compteur = keyId;
            int tailleTableau = tabAscii.Length;

            int i = 0;
            while(compteur/ tailleTableau != 0)
            {
                tab[i] = compteur % tailleTableau;
                compteur = compteur / tailleTableau;
                i++;
            }

            tab[i] = compteur % tabAscii.Length;


            return tab;
        }




       
    }
}
