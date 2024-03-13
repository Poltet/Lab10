﻿using System;
using ClassLibrary1;

namespace Lab10
{
    public class Program
    {
        static double StarTemperature(CelestialBody[] array)   //Средняя температура всех звёзд
        {
            int count = 0;
            double sum = 0;
            foreach (CelestialBody item in array) 
            {
                if (item is Star S)
                {
                    sum += S.Temperature;
                    count++;
                }                   
            }
            if (count != 0)
                return sum / count;
                return 0;
        }
        static double PlanetWeight(CelestialBody[] array)     //Сумма масс всех планет, не являющихся газовыми гигантами 
        { 
            double sum = 0;
            foreach (CelestialBody item in array)
            {
                if (typeof(Planet) == item.GetType())
                    sum += item.Weight;
            }
            return sum;
        }
        static double GasGigantRadius(CelestialBody[] array)   // Максимальный радиус газовых гигантов с кольцами
        {
            double MaxRadius = 0;
            foreach(CelestialBody item in array)
            {
                GasGigant g = item as GasGigant;
                if (g != null && ((GasGigant)item).Rings)
                    if (MaxRadius < item.Radius)
                        MaxRadius = item.Radius;
            }
            return MaxRadius;
        }
        static void Main(string[] args)
        {
            CelestialBody[] array1 = new CelestialBody[20];
            for (int i = 0; i < 5; i++)               // Небесное тело
            {
                CelestialBody C = new CelestialBody();
                C.RandomInit();
                array1[i] = C;
            }
            for (int i = 5; i < 10; i++)              // Звезды
            {
               Star S = new Star();
               S.RandomInit();
                array1[i] = S;
            }
            for (int i = 10; i < 15; i++)            // Планеты
            {
                Planet P = new Planet();
                P.RandomInit();
                array1[i] = P;
            }
            for (int i = 15; i < 20; i++)            // Газовые гиганты
            {
                GasGigant G = new GasGigant();
                G.RandomInit();
                array1[i] = G;
            }
            Console.WriteLine("Просмотр элементов массива с использованием виртуальных методов:");
            foreach (CelestialBody item in array1)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("===== Конец массива с использованием виртуальных методов ====\n");
            Console.WriteLine("\nПросмотр элементов массива с использованием не виртуальных методов:");
            foreach (CelestialBody item in array1)
            {
                item.ShowCelBody();
            }
            Console.WriteLine("===== Конец массива с использованием не виртуальных методов ====\n");

            Console.WriteLine($"Средняя температура звезд {StarTemperature(array1)}");         //2 part
            Console.WriteLine($"Масса планет не гигантов {PlanetWeight(array1)}");
            Console.WriteLine($"max радиус гигантов с кольцами {GasGigantRadius(array1)}");
            GasGigantRadius(array1);
            PlanetWeight(array1);

            //3 part
            IInit[] array2 = new ClassLibrary1.IInit[15];
            for (int i = 0; i < 3; i++)            // Небесное тело
            {
                CelestialBody C = new CelestialBody();
                C.RandomInit();
                array2[i] = C;
            }
            for (int i = 3; i < 6; i++)            // Звезды
            {
                Star S = new Star();
                S.RandomInit();
                array2[i] = S;
            }
            for (int i = 6; i < 9; i++)            // Планеты
            {
                Planet P = new Planet();
                P.RandomInit();
                array2[i] = P;
            }
            for (int i = 9; i < 12; i++)           // Газовые гиганты
            {
                GasGigant G = new GasGigant();
                G.RandomInit();
                array2[i] = G;
            }
            for (int i = 12; i < 15; i++)          // Парковки
            {
                CarParking P = new CarParking();
                P.RandomInit();
                array2[i] = P;
            }
            Console.WriteLine("Исходный массив");
            foreach (IInit item in array1)
            {
                Console.WriteLine(item);
            }
            Array.Sort(array1);                    //Cортировка массива по имени, метод Sort
            Console.WriteLine("Массив отсортирован по имени");
            foreach (IInit item in array1)
            {
                Console.WriteLine(item);
            }
            Array.Sort (array1 , new WeightComparer()); //Сортировка по весу, Comparer
            Console.WriteLine("Массив отсортирован по весу");
            foreach (IInit item in array1)
            {
                Console.WriteLine(item);
            }
            //bin                                  //бинарный поиск
            CelestialBody cb = new CelestialBody("Ф12",100,122,1);
            array1[5] = cb;
            Array.Sort (array1);
            int index = Array.BinarySearch(array1, new CelestialBody("Ф12", 100, 122,1));
            Console.WriteLine("Новый массив отсортирован\n");
            foreach (IInit item in array1)
            {
                Console.WriteLine(item);
            }
            if (index < 0)
                Console.WriteLine("Элемент не найден"); 
            else
                Console.WriteLine($"index 'Ф12' = {index + 1}");
            //Copy                                 //копия и клон     
            CelestialBody body = new CelestialBody();
            body.RandomInit();
            Console.WriteLine($"оригинал:  {body}");
            
            CelestialBody copy = (CelestialBody)body.ShallowCopy();
            Console.WriteLine($"Copy:  {copy}");

            CelestialBody clon = (CelestialBody)body.Clone();
            Console.WriteLine($"Clon:  {clon}");
            Console.WriteLine("После изменения");
            copy.Name = "copy";
            copy.id.Number = 100;
            clon.Name = "clon";
            clon.id.Number = 200;
            Console.WriteLine(body);
            Console.WriteLine(copy);
            Console.WriteLine(clon);


            Console.ReadLine();
        }
    }
}