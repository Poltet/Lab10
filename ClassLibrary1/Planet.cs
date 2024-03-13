using System;

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
        public Planet(string name, double weight, double radius, int id, int satellites): base(name, weight, radius, id)
        {
            Satellites = satellites;
        }
        public override string ToString()
        {
            return "Планета: " + base.ToString() + $"; Кол -во спутников = {Satellites}";
        }
        public override void Show()
        {
            Console.WriteLine($"Планета:\nИмя = {Name};  Вес = {Weight};  Радиус = {Radius};  Кол-во спутников = {Satellites}\n");
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество спутникв плнеты");
            Satellites = Input.IntInput();
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Satellites = rand.Next(0, 1000);
        }
        public object Clone()                 //Глубокая копия
        {
            return new Planet(Name, Weight, Radius, id.Number, Satellites);
        }
        public object ShallowCopy()           //Поверхностное копирование
        {
            return this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            return ((Planet)obj).Weight == Weight && ((Planet)obj).Radius == Radius && ((Planet)obj).Satellites == Satellites;
        }
    }
}
