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

        [TestMethod()]
        public void inverseArrayTest()
        {
            KeyByte key = new KeyByte(16);

            double[] arr = new double[2];
            arr[0] = 25;
            arr[1] = 90;

            double[] arrAttendu = new double[2];
            arrAttendu[0] = 90;
            arrAttendu[1] = 25;

            double[] val = key.inverseArray(arr);

            Assert.ReferenceEquals(arrAttendu, val);
        }
    }
}