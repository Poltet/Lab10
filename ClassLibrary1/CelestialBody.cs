using System;
using System.Text.RegularExpressions;

namespace ClassLibrary1
{
    public class CelestialBody: IInit, IComparable<CelestialBody>, ICloneable, IHasName
    {
        protected double weight;
        protected double radius;
        protected string name;
        public IdNumber id;               //индекс
        static protected Random rand = new Random();
        public string Name                //название
        {
            get { return name; }
            set
            {
                Regex pattern = new Regex(@"[А-Яа-яA-Za-z0-9]+");
                if (pattern.IsMatch(value))
                    name = value;
                else name = "No name";
            }
        }
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
            return $"Небесное тело: " + BaseInf();
        }
        protected virtual string BaseInf()
        {
            return $"{Name},  Вес = {Weight}; Радиус = {Radius}; id: {id.Number}";
        }
        public void ShowCelBody()
        {
            Console.WriteLine($"Небсное тело: Имя = {Name};  Вес = {Weight};  Радиус = {Radius}");
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите id");  // Метод для ввода  с клавиатуры
            id.Number = Input.IntInput();
            Console.WriteLine("Введите название небесного тела");
            Name = Console.ReadLine();
            Console.WriteLine("Введите массу небесного тела");
            Weight = Input.DoubleInput();
            Console.WriteLine("Введите радиус небесного тела");
            Radius = Input.DoubleInput();

        }
        public virtual void RandomInit()      // Метод для формирования объектов класса с помощью ДСЧ
        {
            Name = Names[rand.Next(Names.Length)];
            Weight = rand.Next(0, 10000);
            Radius = rand.Next(0, 10000); 
            id.Number = rand.Next(1,100);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            CelestialBody c = (CelestialBody)obj;
            return Name == c.Name  && Weight == c.Weight && Radius == c.Radius && id.Number == c.id.Number;
        } 
        public int CompareTo(object obj)
        {
            if (obj is CelestialBody celbody)
            {
                return CompareTo(celbody);
            }
            else return -1;         
        }
        public int CompareTo(CelestialBody celbody)
        {
            if (celbody != null)
            {
                if (this.Name.CompareTo(celbody.Name) != 0)            //Сравнение имени
                    return this.Name.CompareTo(celbody.Name);
                if (this.Weight.CompareTo(celbody.Weight) != 0)        //Сравнение веса
                    return this.Weight.CompareTo(celbody.Weight);
                if (this.Radius.CompareTo(celbody.Radius) != 0)        //Сравненние радиуса
                    return (this.Radius.CompareTo(celbody.Radius));
                return (this.id.Number.CompareTo(celbody.id.Number));  //Сравнение ID
            }
            else return -1;
        }
        public virtual object Clone()                 //Глубокая копия
        {
            return new CelestialBody(Name, Weight, Radius, id.Number);
        }
        public object ShallowCopy()           //Поверхностное копирование
        {
            return this.MemberwiseClone();
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + id.Number.GetHashCode();
                hash = hash * 23 + Name.GetHashCode();
                hash = hash * 23 + Weight.GetHashCode();
                hash = hash * 23 + Radius.GetHashCode();
                return hash;
            }
        }
    }
}
