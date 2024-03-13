using System;

namespace ClassLibrary1
{
    public class CarParking : IInit
    {
        int numSlots;
        int numCars;
        Random rand = new Random();
        public int NumCars                //кол-во машин
        {
            get => numCars;
            set
            {
                if (value < 0)
                    throw new Exception("Количество машин не может быть меньше 0");
                else if (value > NumSlots)
                    throw new Exception("Количество машин не может быть больше количества парковочных мест");
                else numCars = value;
            }
        }
        public int NumSlots               //кол-во парковочных мест
        {
            get => numSlots;
            set
            {
                if (value < 0)
                    throw new Exception("Количество парковочных мест не может быть меньше 0");
                else numSlots = value;
            }
        }
        public CarParking()
        {
            NumSlots = 10;
            NumCars = 0;
        }
        public CarParking(int NumCars, int NumSlots)
        {
            this.NumSlots = NumSlots;
            this.NumCars = NumCars;
        }
        public CarParking(CarParking p)
        {
            this.NumSlots = p.NumSlots;
            this.NumCars = p.NumCars;
        }
        public static double Workload(CarParking p)
        {
            return Math.Round(p.NumCars * 100.0 / p.NumSlots, 2);
        }
        public double Workload()
        {
            return Math.Round(NumCars * 100.0 / NumSlots, 2);
        }
        public void ShowCarParking()
        {
            Console.WriteLine($"\nКоличество машин = {NumCars}");
            Console.WriteLine($"Количество парковочных мест = {NumSlots}");
            Console.WriteLine($"Загруженность парковки {Workload()}%\n");
        }

        public static CarParking operator ++(CarParking p)
        {
            CarParking temp = new CarParking(p);
            temp.NumCars = temp.NumCars + 1;
            return temp;
        }
        public static CarParking operator --(CarParking p)
        {
            CarParking temp = new CarParking(p);
            temp.NumCars = temp.NumCars - 1;
            return temp;
        }
        public static explicit operator int(CarParking p) // Явное приведениие
        {
            if (p.numSlots * 80 / 100 - p.NumCars>0)
                return p.numSlots * 80 / 100 - p.NumCars;
            else return 0;
        }
        public static implicit operator bool(CarParking p)
        {
            return p.NumSlots > p.NumCars;
        }
        public static CarParking operator +(CarParking cp1, CarParking cp2)
        {
            CarParking temp = new CarParking();
            temp.NumSlots = cp1.NumSlots + cp2.NumSlots;
            temp.NumCars = cp1.NumCars + cp2.NumCars;
            return temp;
        }
        public static bool operator >(CarParking cp1, CarParking cp2)
        {
            return cp1.Workload() < cp2.Workload() && cp1.NumSlots > cp2.NumSlots; //
        }
        public static bool operator <(CarParking cp1, CarParking cp2)
        {
            return Workload(cp1) > Workload(cp2) && cp1.NumSlots < cp2.NumSlots; //
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((CarParking)obj).NumSlots == NumSlots && ((CarParking)obj).NumCars == NumCars;
        }
        public override string ToString()
        {
            return $"{NumCars} машин(ы) и {NumSlots} парковок";
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите количество парковочных мест");
            NumSlots = Input.IntInput();
            Console.WriteLine("Введите количество машин");
            NumCars = Input.IntInput();
        }
        public virtual void RandomInit()
        {
            NumSlots = rand.Next(1, 100);
            NumCars = rand.Next(1, NumSlots);
        }
    }
}
