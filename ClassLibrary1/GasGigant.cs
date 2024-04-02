using System;

namespace ClassLibrary1
{
    public class GasGigant : Planet
    {
        public bool Rings { get; set; }  //наличие колец
        public GasGigant() : base()      //конструктор без параметров
        {
            Rings = true;
        }
        public GasGigant(string name, double weight, double radius, int id, int satellites, bool rings) : base(name, weight, radius, id, satellites)
        {
            Rings = rings;
        }
        public override string ToString()
        {
            return "Газовый гигант: " + base.ToString() + $" ;Наличие колец - {Rings}";
        }
        public override void Show()              //Show виртуальный 
        {
            base.Show();
            Console.WriteLine($"Наличие колец - {Rings}\n");
        }
        public new void ShowCelBody()
        {
            base.ShowCelBody();
            Console.WriteLine($"Наличие колец - {Rings}\n");
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество колец");
            int K = Input.IntInput();
            if (K > 0)
                Rings = true;
            else Rings = false;
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Rings = (rand.Next(0, 2) == 1);
        }
        public override object Clone()                 //Глубокая копия
        {
            return new GasGigant(Name, Weight, Radius, id.Number, Satellites, Rings);
        }
        public object ShallowCopy()           //Поверхностное копирование
        {
            return this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            return (base.Equals(obj) && ((GasGigant)obj).Rings == Rings);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        //public override bool Equals(object obj)
        //{
        //    if (obj == null || GetType() != obj.GetType())
        //        return false;
        //    return ((GasGigant)obj).Weight == Weight && ((GasGigant)obj).Radius == Radius && ((GasGigant)obj).Satellites == Satellites && ((GasGigant)obj).Rings == Rings;
        //}
    }
}
