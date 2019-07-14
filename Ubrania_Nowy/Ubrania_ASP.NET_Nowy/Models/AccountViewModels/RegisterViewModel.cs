using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ubrania_ASP.NET_Nowy.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        //[Required]
        //[Display(Name = "Agreement_ID")]
        //public string Agreement_Id { get; set; }

        //[Required]
        //[StringLength(100, MinimumLength = 6)]
        //[Display(Name = "Pesel")]
        //public string Pesel { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }




        [Required]
        [Display(Name = "Agreement_ID")]
        public string Agreement_Id { get; set; }
        [Required]
        [Display(Name = "Pesel")]
        public string Pesel { get; set; }
    }
}
