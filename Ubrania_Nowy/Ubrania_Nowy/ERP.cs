using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Ubrania_Nowy
{
    public class Agreement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Tel { get; set; }
        public int Pesel { get; set; }
        public DateTime Begin { get; set; }        
        public DateTime End { get; set; }
        public IList<Cloth> Clothes { get; set; }
    }
    public class Cloth
    {

        public int Id { get; set; }
        public string Mark { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Price_RL { get; set; }
        public int Agreement_Id { get; set; }
        public bool Sold { get; set; }
        public Agreement Agreement { get; set; }
    }
      
}
