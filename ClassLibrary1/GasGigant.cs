using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary1
{
    public class GasGigant : Planet
    {
        public bool Rings { get; set; }  //наличие колец
        public GasGigant() : base()        //конструктор без параметров
        {
            Rings = true;
        }
        public GasGigant(bool rings) : base()
        {
            Rings = rings;
        }
        //public override void Show()
        //{
        //    Console.WriteLine($"Газовый гигант: Имя = {Name};  Вес = {Weight};  Радиус = {Radius};  Кол-во спутников = {Satellites};  Наличие колец - {Rings}\n");
        //}
        public override string ToString()
        {
            return "Газовый гигант: " + base.ToString() + $" ;Наличие колец - {Rings}";
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество колец");
            try
            {
                int K = int.Parse(Console.ReadLine());
                if (K > 0 ) 
                    Rings = true;
                else Rings = false;
            }
            catch
            {
                Rings= false;
            }
        }
        public override void RandomInit()
        {
            base.RandomInit();
            if (rand.Next(0, 1) == 0)
                Rings = false;
            else Rings = true;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((GasGigant)obj).Weight == Weight && ((GasGigant)obj).Radius == Radius && ((GasGigant)obj).Satellites == Satellites && ((GasGigant)obj).Rings == Rings;
        }
    }
}
