using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class CelestialBody: IInit, IComparable
    {
        protected double weight;
        protected double radius;
        public static int count = 0;  //счетчик небесных тел
        protected Random rand = new Random();
        public string Name { get; set; }  //название
        public double Weight              //масса
        {
            get { return weight; }
            set
            {
                if (value < 0)
                {
                    weight = 0;
                    Console.WriteLine("Вес не может быть меньше 0");
                }
                else weight = value;
            }
        }
        public double Radius              //радиус
        {
            get { return radius; }
            set
            {
                if (value < 0)
                {
                    radius = 0;
                    Console.WriteLine("Радиус не может быть меньше 0");
                }
                else radius = value;
            }
        }
        static string[] Names = {"Сириус", "Солнце", "Земля", "Марс", "Юпитер", "Вега", "Антарес", "Арктур", "Алькор", "Сатурн", "Уран", "Нептун", "Тампеля", "Глизе", "Денеб", "Мицар", "Алиот", "Кастор", "Авиор", "Луна", "Ио", "Диона", "Тефия", "Миранда" };
        public CelestialBody()            //конструктор без параметров
        {
            count++;
            Name = $"Небесное тело {count}";
            Weight = 10;
            Radius = 10;
        }
        public CelestialBody(string name, double weight, double radius) //конструктор c параметрами
        {
            count++;
            Name = name;
            Weight = weight;
            Radius = radius;
        }
        public virtual void Show()
        {
            Console.WriteLine($"Небсное тело: Имя = {Name};  Вес = {Weight};  Радиус = {Radius}\n");
        }
        public override string ToString()
        {
            return $"Небесное тело: Имя = {Name};  Вес = {Weight}; Радиус = {Radius}";
        }
        public virtual void Init(string name, double weight, double radius)
        {
            Name = name;
            Weight = weight;
            Radius = radius;
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите название");
            Name = Console.ReadLine();
            Console.WriteLine("Введите массу");
            try
            {
                Weight = int.Parse(Console.ReadLine());
            }
            catch { Weight = 100; }
            try
            {
                Radius = int.Parse(Console.ReadLine());
            }
            catch { Radius = 100; }
        }

        public virtual void RandomInit()
        {
            Name = Names[rand.Next(Names.Length)];
            Weight = rand.Next(0, 10000) + Math.Round(rand.NextDouble(), 2);
            Radius = rand.Next(0, 10000) + Math.Round(rand.NextDouble(), 2);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((CelestialBody)obj).Weight == Weight && ((CelestialBody)obj).Radius == Radius && ((CelestialBody)obj).Name == Name;
        }

        public int CompareTo(object obj)
        {
            CelestialBody c = obj as CelestialBody;
            if (c != null)
                return String.Compare(this.Name, c.Name);
            else return -1;
            
        }
    }
}
