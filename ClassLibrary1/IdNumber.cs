using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class IdNumber
    {
        public int Number { get; set; }
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
