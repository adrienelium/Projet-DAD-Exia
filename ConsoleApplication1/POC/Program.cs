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
            var timeStarted = DateTime.Now;
            Console.WriteLine("Starting now...");
            KeyByte key = new KeyByte(64);            

            for (int i = 0; i < 5000; i++)
            {
                key.GetKey();
            }

            Console.WriteLine("Time passed: {0}s", DateTime.Now.Subtract(timeStarted).TotalSeconds);
            Console.Read();

        }


    }
}
