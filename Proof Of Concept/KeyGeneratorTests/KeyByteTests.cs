using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeyGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGenerator.Tests
{
    [TestClass()]
    public class KeyByteTests
    {

        [TestMethod()]
        public void SizeKeyTest()
        {
            KeyByte key = new KeyByte(32);

            string str = key.GetKey();

            Assert.AreEqual(4, str.Length);
        }

        [TestMethod()]
        public void DifferentIncrementKeyTest()
        {
            KeyByte key = new KeyByte(32);

            string str1 = key.GetKey();
            string str2 = key.GetKey();

            Assert.AreNotEqual(str1, str2);
        }
    }
}