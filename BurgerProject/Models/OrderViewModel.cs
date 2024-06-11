using BurgerProject.Data.Entities.Concrete;
using BurgerProject.Data.Enums;

namespace BurgerProject.Models
{
    public class OrderViewModel
    {



        public int MenuId { get; set; }
        public OrderSize OrderSize { get; set; }
        public int Piece { get; set; }
        public List<Extra>? Extras { get; set; } 


    }
}
