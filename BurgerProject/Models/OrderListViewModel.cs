using BurgerProject.Data.Entities.Concrete;
using BurgerProject.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BurgerProject.Models
{
    public class OrderListViewModel
    {
        



        public int Id { get; set; } 
        public OrderSize OrderSize { get; set; }
        public int Piece { get; set; }
       
        public string MenuName { get; set; }
        public double TotalPrice { get; set; }

        // İlişkiler
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public List<Extra>? Extras { get; set; }
        public int MenuId { get; set; }
        public Menu? Menu { get; set; }

    }
}
