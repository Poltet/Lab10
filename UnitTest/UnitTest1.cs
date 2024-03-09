using ClassLibrary1;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_CarParking_Constructor()  // Парковки конструктор с параметром и без
        {
            CarParking expected = new CarParking(0,10);
            CarParking actual = new CarParking();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod_CarParking_CopyConstructor()  // Парковки конструктор копирования
        {
            CarParking expected = new CarParking(0, 10);
            CarParking actual = new CarParking(expected);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod_Carparking_Increment()
        {
            CarParking expected = new CarParking(2, 3);
            CarParking actual = new CarParking(1, 3);
            actual++;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod_Carparking_IncrementEror()
        {
            CarParking actual = new CarParking(1, 1);
            Assert.ThrowsException<Exception>(() => { actual++; });
        }
        [TestMethod]
        public void TestMethod_Carparking_Dicrement()
        {
            CarParking expected = new CarParking(2, 3);
            CarParking actual = new CarParking(3, 3);
            actual--;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod_Carparking_DicrementEror()
        {
            CarParking actual = new CarParking(0, 1);
            Assert.ThrowsException<Exception>(() => { actual--; });
        }
        [TestMethod]
        public void TestMethod_CelestialBodyConstructor()
        {
            CelestialBody expected = new CelestialBody("А510", 10, 10, 1);
            CelestialBody actual = new CelestialBody();
            Assert.AreEqual(expected, actual);
        }
    }
}
