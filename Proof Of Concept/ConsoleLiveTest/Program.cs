using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyGenerator;

namespace ConsoleLiveTest
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyGenerator.KeyByte keygen = new KeyByte(32);

            while (keygen.nextKeyExist())
            {
                Console.WriteLine(keygen.GetKey());
            }
            
            Console.ReadLine();
        }
    }
}
