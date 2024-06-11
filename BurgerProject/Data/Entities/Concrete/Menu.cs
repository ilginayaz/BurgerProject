using BurgerProject.Data.Entities.Abstract;

namespace BurgerProject.Data.Entities.Concrete
{
	public class Menu  : BaseEntity
	{
        public string MenuName { get; set; }
        public double MenuPrice { get; set; }
        public double MenuPiece { get; set; }

		public string? ImageName { get; set; }

        //iliskiler

        public List<Order> Orders { get; set; }


    }
}
