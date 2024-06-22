using Microsoft.AspNetCore.Identity;

namespace BurgerProject.Data.Entities.Concrete
{
    public class AppUser : IdentityUser<int>
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Address { get; set; }


        //iliskiler

        public List<Order>? Orders { get; set; }




    }
}
