using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ubrania_ASP.NET2.Models
{
    public class Agreement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Tel { get; set; }
        public double Pesel { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public IList<Cloth> Clothes { get; set; }
    }
}
