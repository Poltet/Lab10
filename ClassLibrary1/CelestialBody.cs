using System;


namespace ClassLibrary1
{
    public class CelestialBody: IInit, IComparable, ICloneable
    {
        protected double weight;
        protected double radius;
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
        public IdNumber id;               //индекс
        static string[] Names = {"Сириус", "Солнце", "Земля", "Марс", "Юпитер", "Вега", "Антарес", "Арктур", "Алькор", "Сатурн", "Уран", "Нептун", "Тампеля", "Глизе", "Денеб", "Мицар", "Алиот", "Кастор", "Авиор", "Луна", "Ио", "Диона", "Тефия", "Миранда" };
        public CelestialBody()            //конструктор без параметров
        {
            Name = $"A510";
            Weight = 10;
            Radius = 10;
            id = new IdNumber(1);
        }
        public CelestialBody(string name, double weight, double radius) //конструктор c параметрами
        {
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
            Console.WriteLine("Введите id");
            try
            {
                id.Number = int.Parse(Console.ReadLine());
            }
            catch
            {
                id.Number = 0;
            }
            Console.WriteLine("Введите название небесного тела");
            Name = Console.ReadLine();
            Console.WriteLine("Введите массу небесного тела");
            try
            {
                Weight = double.Parse(Console.ReadLine());
            }
            catch 
            { 
                Weight = 100;
            }
            Console.WriteLine("Введите радиус небесного тела");
            try
            {
                Radius = double.Parse(Console.ReadLine());
            }
            catch
            {
                Radius = 100;
            }
        }

        public virtual void RandomInit()
        {
            Name = Names[rand.Next(Names.Length)];
            Weight = rand.Next(0, 10000) + Math.Round(rand.NextDouble(), 2);
            Radius = rand.Next(0, 10000) + Math.Round(rand.NextDouble(), 2);
            id.Number = rand.Next(1,100);
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
        public object Clone()
        {
            return new CelestialBody(Name, Weight, Radius);
        }
    }
}
