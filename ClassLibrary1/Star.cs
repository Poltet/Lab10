using System;
using System.Net.NetworkInformation;

namespace ClassLibrary1
{
    public class Star : CelestialBody
    {
        double temperature;
        public double Temperature                   //температура 
        {
            get { return temperature; }
            set
            {
                if (value < 3000 || value > 30_000)
                    temperature = 3500;
                else temperature = value;
            }             
        }
        public Star() : base()                      //конструктор без парамеров 
        {
            Temperature = 3500;
        }
        public Star(string name, double weight, double radius, int id, double temperature) : base(name, weight, radius, id)  
        {
            Temperature = temperature;
        }
        public override string ToString()
        {
            return "Звезда: " + base.ToString() + $" ;Температура = {Temperature}";
        }
        public override void Show()
        {
            Console.WriteLine($"Звезда:\nИмя = {Name};  Вес = {Weight};  Радиус = {Radius};  Температура = {Temperature}\n");
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите температуру звезды");
            Temperature = Input.DoubleInput();
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Temperature = rand.Next(3000, 10000) + Math.Round(rand.NextDouble(), 2);
        }
        public object Clone()                 //Глубокая копия
        {
            return new Star(Name, Weight, Radius, id.Number, Temperature);
        }
        public object ShallowCopy()           //Поверхностное копирование
        {
            return this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((Star)obj).Weight == Weight && ((Star)obj).Radius == Radius && ((Star)obj).Temperature == Temperature;
        }
        //public override bool Equals(object obj)
        //{
        //    return (base.Equals(obj) && ((Star)obj).Temperature == Temperature);         
        //}
        //public override bool Equals(object obj)
        //{
        //    if (!base.Equals(obj))
        //        return false;
        //    Star st = (Star)obj;
        //    return st.Temperature == Temperature;
        //}
    }
}
