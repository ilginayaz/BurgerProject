using BurgerProject.Data.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace BurgerProject.Models.Account
{
    public class UserViewModel
    {

        public int UserId { get; set; }

        [Display(Name ="Ad")]
        public string? Name { get; set; }
        [Display(Name = "Soyad")]
        public string? Surname { get; set; }
        [Display(Name = "Adres")]
        public string? Address { get; set; }

		[EmailAddress]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }



        [DataType(DataType.Password)]
        public string? Password { get; set; }



        [DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Şifre ile şifre tekrarı aynı değildir.")]
        public string? ConfirmPassword { get; set; }








        //iliskiler

        //public List<OrderViewModel>? Orders { get; set; }

    }
}
