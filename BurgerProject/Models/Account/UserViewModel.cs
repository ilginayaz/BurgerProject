using BurgerProject.Data.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace BurgerProject.Models.Account
{
    public class UserViewModel
    {

        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
		public string? Address { get; set; }

		[EmailAddress]
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
