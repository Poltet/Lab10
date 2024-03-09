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
        public CelestialBody(string name, double weight, double radius, int id) //конструктор c параметрами
        {
            Name = name;
            Weight = weight;
            Radius = radius;
            this.id = new IdNumber(id);
        }
        public virtual void Show()
        {
            Console.WriteLine($"Небсное тело: Имя = {Name};  Вес = {Weight};  Радиус = {Radius}\n");
        }
        public override string ToString()
        {
            return $"Небесное тело: Имя = {Name};  Вес = {Weight}; Радиус = {Radius}; id: {id.Number}";
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите id");  // Метод для ввода  с клавиатуры
            id.Number = IntInput();
            Console.WriteLine("Введите название небесного тела");
            Name = Console.ReadLine();
            Console.WriteLine("Введите массу небесного тела");
            Weight = DoubleInput();
            Console.WriteLine("Введите радиус небесного тела");
            Radius = DoubleInput();

        }
        public virtual void RandomInit()      // Метод для формирования объектов класса с помощью ДСЧ
        {
            Name = Names[rand.Next(Names.Length)];
            Weight = rand.Next(0, 10000) + Math.Round(rand.NextDouble(), 2);
            Radius = rand.Next(0, 10000) + Math.Round(rand.NextDouble(), 2);
            id.Number = rand.Next(1,100);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is CelestialBody c)
                return this.Name == c.Name && this.Weight == c.Weight && this.Radius == c.Radius && this.id.Number == c.id.Number;
            return false;
        }
        public int CompareTo(object obj)
        {
            CelestialBody c = obj as CelestialBody;
            if (c != null)
                return String.Compare(this.Name, c.Name);
            else return -1;         
        }
        public object Clone()                 //Глубокая копия
        {
            return new CelestialBody(Name, Weight, Radius, id.Number);
        }
        public object ShallowCopy()           //Поверхностное копирование
        {
            return this.MemberwiseClone();
        }
        public static int IntInput()          //Метод для ввода целого числа
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                return 0;
            }
        }
        public static double DoubleInput()    //Метод для ввода дробного числа
        {
            try
            {
                return double.Parse(Console.ReadLine());
            }
            catch
            {
                return 0;
            }
        }
    }
}
