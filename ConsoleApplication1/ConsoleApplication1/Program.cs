using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyGenerator;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyByte key = new KeyByte();
            int[] tab = key.getKeyInBase();

            for (int i = 0; i < tab.Length; i++)
            {

                    Console.WriteLine(tab[i]);
                
            }


            Console.Read();

        }


    }
}
