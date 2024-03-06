using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Star : CelestialBody
    {
        public double Temperature { get; set; }     //температура 
        public Star() : base()                       //конструктор без парамеров 
        {
            Temperature = -50.9;
        }
        public Star(double temperature) : base()
        {
            Temperature = temperature;
        }
        //public override void Show()
        //{
        //    Console.WriteLine($"Звезда: Имя = {Name};  Вес = {Weight};  Радиус = {Radius};  Температура = {Temperature}\n");
        //}
        public override string ToString()
        {
            return "Звезда: " + base.ToString() + $" ;Температура = {Temperature}";
        }
        public override void Init()
        {
            base.Init();
            try
            {
                 Temperature = int.Parse(Console.ReadLine());
            }
            catch
            {
                Temperature = 0;
            }
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Temperature = rand.Next(0, 10000) + Math.Round(rand.NextDouble(), 2);
        }
    }
}
