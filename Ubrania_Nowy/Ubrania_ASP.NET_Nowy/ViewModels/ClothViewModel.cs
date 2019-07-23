using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ubrania_ASP.NET_Nowy.Models;

namespace Ubrania_ASP.NET_Nowy.ViewModels
{
    public class ClothViewModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        public int PriceCounter { get; set; }
        public List<Cloth> ClothList { get; set; } = new List<Cloth>();
    }
}
