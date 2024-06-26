﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ClassLibrary1
{
    public class TestCollections
    {
        LinkedList<Planet> col1 = new LinkedList<Planet>();
        LinkedList<string> col2 = new LinkedList<string>();
        public SortedSet<CelestialBody> col3 = new SortedSet<CelestialBody>();
        SortedSet<string> col4 = new SortedSet<string>();
        public TestCollections()
        {
            for (int i = 0; i < 1000; i++)
            {
                Planet planet = new Planet();
                planet.RandomInit();
                planet.Name = planet.Name + i.ToString();
                if (i == 0)
                    planet = new Planet("1", 1, 1, 1, 1);
                if (i == 500)
                    planet = new Planet("2", 2, 2, 2, 2);
                if (i == 999)
                    planet = new Planet("3", 3, 3, 3, 3);
                col1.AddLast(planet);
                col2.AddLast(planet.ToString());
                col3.Add(planet.GetBase);
                col4.Add(planet.GetBase.ToString());
            }
        }
        public (bool, long) SearchTime(Planet SearchElement, int collection) //Поиск элемента и измерение времени
        {
            Stopwatch stopwatch = new Stopwatch();
            bool ok = false;
            long time = 0;
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
                        string SearchElement1 = SearchElement.ToString();
                        stopwatch.Restart();
                        ok = col2.Contains(SearchElement1);
                        stopwatch.Stop();
                        time = stopwatch.ElapsedTicks; ;
                        break;
                    }
                case 3:  //Коллекция 3
                    {
                        CelestialBody SearchElement1 = SearchElement.GetBase;
                        stopwatch.Restart();
                        ok = col3.Contains(SearchElement1);
                        stopwatch.Stop();
                        time = stopwatch.ElapsedTicks;
                        break;
                    }
                case 4:  //Коллекция 4
                    {
                        string SearchElement1 = SearchElement.GetBase.ToString();
                        stopwatch.Restart();
                        ok = col4.Contains(SearchElement1);
                        stopwatch.Stop();
                        time = stopwatch.ElapsedTicks;
                        break;
                    }
            }
            return (ok, time);
        }
    }
}
