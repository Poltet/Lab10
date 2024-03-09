using System;

namespace ClassLibrary1
{
    public class Star : CelestialBody
    {
        public double Temperature { get; set; }     //температура 
        public Star() : base()                      //конструктор без парамеров 
        {
            Temperature = -50;
        }
        public Star(double temperature) : base()
        {
            Temperature = temperature;
        }
        public override string ToString()
        {
            return "Звезда: " + base.ToString() + $" ;Температура = {Temperature}";
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите температуру звезды");
            Temperature = DoubleInput();
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Temperature = rand.Next(0, 10000) + Math.Round(rand.NextDouble(), 2);
        }
    }
}
