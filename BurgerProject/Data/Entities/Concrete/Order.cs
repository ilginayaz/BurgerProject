using BurgerProject.Data.Entities.Abstract;
using BurgerProject.Data.Enums;

namespace BurgerProject.Data.Entities.Concrete
{
	public class Order : BaseEntity
	{
        public OrderSize OrderSize { get; set; }
        public int Piece { get; set; }


		//iliskiler

		public int AppUserId { get; set; }
		public AppUser? AppUser { get; set; }


		public List<Extra>? Extras { get; set; }
		

        public  int MenuId { get; set; }
        public Menu? Menu { get; set; }




    }
}
