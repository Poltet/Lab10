using ClassLibrary1;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //===== class CarParking =====
        
        [TestMethod]
        public void TestMethod_CarParking_Constructor()      // Парковки конструктор с параметром и без
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
        public void TestMethod_CarParking_NegativeNumSlots() 
        {
            CarParking p = new CarParking();
            Assert.ThrowsException<Exception>(() => { new CarParking(1, -2); });
        }
        [TestMethod]
        public void TestMethod_CarParking_NegativeNumCars()
        {
            CarParking p = new CarParking();
            Assert.ThrowsException<Exception>(() => { new CarParking(-1, 6); });
        }
        [TestMethod]
        public void TestMethod_CarParking_CarsMoreSlots()
        {
            CarParking p = new CarParking();
            Assert.ThrowsException<Exception>(() => { new CarParking(6, 2); });
        }
        [TestMethod]
        public void TestMethod_Carparking_Workload()         // Загруженность парковки, статический и нестатичесский метод
        {
            CarParking p = new CarParking(2, 3);
            double expected = p.Workload();
            double actual = CarParking.Workload(p);
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
        public void TestMethod_Carparking_IncrementError()
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
        public void TestMethod_Carparking_DicrementError()
        {
            CarParking actual = new CarParking(0, 1);
            Assert.ThrowsException<Exception>(() => { actual--; });
        }
        [TestMethod]
        public void TestMethod_Carparking_OperetorPlus()
        {
            CarParking expected = new CarParking(5, 20);
            CarParking actual1 = new CarParking(2, 10);
            CarParking actual2 = new CarParking(3, 10);
            CarParking actual = actual1 + actual2;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod_Carparking_BoolOperators()    //
        {
            CarParking p1 = new CarParking(2, 5);
            CarParking p2 = new CarParking(2, 10);
            bool expected = p2 > p1;
            bool actual = p1 < p2;
            Assert.AreEqual(expected, actual);
        }
        //===== class CelestialBody =====

        [TestMethod]
        public void TestMethod_CelestialBody_Constructor()
        {
            CelestialBody expected = new CelestialBody("А510", 10, 10, 1);
            CelestialBody actual = new CelestialBody();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod_CelestialBody_Error()         //Отрицательный вес, радиус, индекс небесного тела
        {
            CelestialBody expected = new CelestialBody("N20", -20, -10, -1);
            CelestialBody actual = new CelestialBody("N20", 0, 0, 0);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod_CelestialBody_Clon()         //Клонирование
        {
            CelestialBody expected = new CelestialBody("F10", 50, 10, 1);
            CelestialBody actual = (CelestialBody)expected.Clone();
            actual.Weight = 100;
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod_CelestialBody_Copy()         //Поверхностное копирование
        {
            CelestialBody expected = new CelestialBody("F10", 50, 10, 1);
            CelestialBody actual = (CelestialBody)expected.ShallowCopy();          
            actual.Weight = 100;           
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod_CompareTo()                  //Сортировка по имени
        {
            CelestialBody[] array = new CelestialBody[3];
            array[0] = new CelestialBody("B",1,1,1);
            array[1] = new CelestialBody("C",1,1,1);
            array[2] = new CelestialBody ("A",1,1,1);
            Array.Sort(array);
            Assert.IsTrue(array[0].Name == "A");
        }
        [TestMethod]
        public void TestMethod_WeightComparer()             //Сортировка по весу (второй параметр)
        {
            CelestialBody[] array = new CelestialBody[3];
            array[0] = new CelestialBody("B", 30, 1, 1);
            array[1] = new CelestialBody("C", 10, 1, 1);
            array[2] = new CelestialBody("A", 20, 1, 1);
            Array.Sort(array, new WeightComparer());
            Assert.IsTrue(array[0].Weight == 10);
        }
        //===== class Planet =====

        [TestMethod]
        public void TestMethod_Planet_Constructor()
        {
            Planet expected = new Planet(1);
            Planet actual = new Planet();
            Assert.AreEqual(expected, actual);
        }
        //===== class GasGigant =====

        [TestMethod]
        public void TestMethod_GasGigant_Constructor()
        {
            GasGigant expected = new GasGigant(true);
            GasGigant actual = new GasGigant();
            Assert.AreEqual(expected, actual);
        }
        //===== class Star =====

        [TestMethod]
        public void TestMethod_Star_Constructor()
        {
            Star expected = new Star(-50);
            Star actual = new Star();
            Assert.AreEqual(expected, actual);
        }
    }
}
