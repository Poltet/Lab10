﻿using System;

namespace ClassLibrary1
{
    public class Planet : CelestialBody
    {
        protected int satellites;
        public int Satellites              //количество спутников
        {
            get { return satellites; }
            set
            {
                if (value < 0)
                {
                    satellites = 0;
                    Console.WriteLine("Количество спутников не может быть меньше 0");
                }
                else satellites = value;
            }
        }
        public Planet() : base()            //конструктор без параметров
        {
            Satellites = 1;
        }
        public Planet(int satellites) : base()
        {
            Satellites = satellites;
        }
        public override string ToString()
        {
            return "Планета: " + base.ToString() + $"; Кол -во спутников = {Satellites}";
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество спутникв плнеты");
            Satellites = IntInput();
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Satellites = rand.Next(0, 1000);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((Planet)obj).Weight == Weight && ((Planet)obj).Radius == Radius && ((Planet)obj).Satellites == Satellites;
        }
    }
}
