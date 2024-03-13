using System;

namespace ClassLibrary1
{
    public class IdNumber
    {
        int number;
        public int Number
        {
            get { return number; }
            set
            {
                if (value < 0)
                {
                    number = 0;
                    Console.WriteLine("Индекс не может быть меньше 0");
                }
                else number = value;
            }
        }
        
        public IdNumber(int Number)
        {
            this.Number = Number;
        }
        public override string ToString()
        {
            return Number.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is IdNumber n)
                return this.Number == n.Number;
            return false;
        }
    }
}
