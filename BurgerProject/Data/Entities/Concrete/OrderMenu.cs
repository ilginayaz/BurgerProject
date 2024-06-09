using BurgerProject.Data.Entities.Abstract;

namespace BurgerProject.Data.Entities.Concrete
{
	public class OrderMenu : BaseEntity
	{
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int MenuId { get; set; }
        public Menu? Menu { get; set; }


    }
}
