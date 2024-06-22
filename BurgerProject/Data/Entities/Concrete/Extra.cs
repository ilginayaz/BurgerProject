using BurgerProject.Data.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BurgerProject.Data.Entities.Concrete
{
	public class Extra : BaseEntity
	{
        public string ExtraName { get; set; }
        public double ExtraPrice { get; set; }

        public string? LogoFile { get; set; }


        //iliskiler

        public int? OrderId { get; set; }
        public List<Order>? Order { get; set; }


    }
}
