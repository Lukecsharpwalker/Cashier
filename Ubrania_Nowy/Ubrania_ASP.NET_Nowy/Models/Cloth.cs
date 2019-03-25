using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ubrania_ASP.NET_Nowy.Models
{
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
