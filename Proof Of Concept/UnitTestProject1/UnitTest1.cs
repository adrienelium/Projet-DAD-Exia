using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeyGenerator;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            KeyByte key = new KeyByte();
            Console.WriteLine(key.GetMaxByteValue(8));
        }
    }
}
