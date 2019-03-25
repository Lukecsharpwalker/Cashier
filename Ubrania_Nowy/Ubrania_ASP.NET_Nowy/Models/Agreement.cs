using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ubrania_ASP.NET_Nowy.Models
{
    public class Agreement
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public double Tel { get; set; }
        public double Pesel { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public IList<Cloth> Clothes { get; set; }
    }
}
