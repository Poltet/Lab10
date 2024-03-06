using System;
using System.Diagnostics.Eventing.Reader;
using ClassLibrary1;

namespace Lab10
{
    internal class Program
    {
        static void StarTemperature(CelestialBody[] array)   //Средняя температура всех звёзд
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
                Console.WriteLine($"Средняя температура звезд = {sum / count}");
            else Console.WriteLine("Звезд нет");
        }
        static void PlanetWeight(CelestialBody[] array)     //Сумма масс всех планет, не являющихся газовыми гигантами 
        { 
            double sum = 0;
            foreach (CelestialBody item in array)
            {
                if (typeof(Planet) == item.GetType())
                    sum += item.Weight;
            }
            Console.WriteLine($"Сумма масс всех планет = {sum}"); 
        }
        static void GasGigantRadius(CelestialBody[] array)   // Максимальный радиус газовых гигантов с кольцами
        {
            double MaxRadius = 0;
            foreach(CelestialBody item in array)
            {
                GasGigant g = item as GasGigant;
                if (g != null && ((GasGigant)item).Rings)
                    MaxRadius = Math.Max(MaxRadius, item.Radius);
            }
            if (MaxRadius != 0)
                Console.WriteLine($"Максимальный радиус газовых гигантов с кольцами = {MaxRadius}");
            else
                Console.WriteLine("Гигантов с кольцами не нашлось");
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
                item.Show();
            }
            Console.WriteLine("===== Конец массива с использованием не виртуальных методов ====\n");

            StarTemperature(array1);
            GasGigantRadius(array1);
            PlanetWeight(array1);
          

            Console.ReadLine();
        }
    }
}