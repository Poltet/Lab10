using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ClassLibrary1
{
    public class TestCollections
    {
        LinkedList<Planet> col1 = new LinkedList<Planet>();
        LinkedList<string> col2 = new LinkedList<string>();
        SortedSet<CelestialBody> col3 = new SortedSet<CelestialBody>();
        SortedSet<string> col4 = new SortedSet<string>();
        public TestCollections()
        {
            Planet planet1 = new Planet("1",1,1,1,1);
            col1.AddLast(planet1);
            col2.AddLast(planet1.ToString());
            col3.Add(planet1);
            col4.Add(planet1.ToString());
            for (int i = 0; i < 500; i++)
            {
                Planet planet = new Planet();
                planet.RandomInit();
                col1.AddLast(planet);
                col2.AddLast(planet.ToString());
                col3.Add(planet);
                col4.Add(planet.ToString());
            }
            Planet planet2 = new Planet("2", 2, 2, 2, 2);
            col1.AddLast(planet2);
            col2.AddLast(planet2.ToString());
            col3.Add(planet2);
            col4.Add(planet2.ToString());
            for (int i = 500; i < 1000; i++)
            {
                Planet planet = new Planet();
                planet.RandomInit();
                col1.AddLast(planet);
                col2.AddLast(planet.ToString());
                col3.Add(planet);
                col4.Add(planet.ToString());
            }
            Planet planet3 = new Planet("3", 3, 3, 3, 3);
            col1.AddLast(planet2);
            col2.AddLast(planet3.ToString());
            col3.Add(planet3);
            col4.Add(planet3.ToString());
        }
        public (bool, long) SearchTime(Planet SearchElement, int collection) //Поиск элемента и измерение времени
        {
            Stopwatch stopwatch = new Stopwatch();
            bool ok = false;
            long time = stopwatch.ElapsedTicks;
            switch (collection)
            {
                case 1:  //Коллекция 1
                    {
                        stopwatch.Restart();
                        ok = col1.Contains(SearchElement);
                        stopwatch.Stop();
                        time = stopwatch.ElapsedTicks;
                        break;
                    }
                case 2:  //Коллекция 2
                    {
                        stopwatch.Start();
                        ok = col2.Contains(SearchElement.ToString());
                        stopwatch.Stop();
                        time = stopwatch.ElapsedTicks; ;
                        break;
                    }
                case 3:  //Коллекция 3
                    {
                        stopwatch.Start();
                        ok = col3.Contains(SearchElement);
                        stopwatch.Stop();
                        time = stopwatch.ElapsedTicks;
                        break;
                    }
                case 4:  //Коллекция 4
                    {
                        stopwatch.Start();
                        ok = col4.Contains(SearchElement.ToString());
                        stopwatch.Stop();
                        time = stopwatch.ElapsedTicks;
                        break;
                    }
            }
            return (ok, time);
        }
    }
}
