using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ubrania_ASP.NET_Nowy.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Agreement_Id { get; set; }
        [Required]
        [Display(Name = "Pesel")]
        public string Pesel { get; set; }


        //[Required]
        //public string Email { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }


        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
