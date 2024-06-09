using BurgerProject.Data.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BurgerProject.Data.Entities.Concrete
{
	public class Extra : BaseEntity
	{
        public string ExtraName { get; set; }
        public double ExtraPrice { get; set; }


        //iliskiler

        public int OrderId { get; set; }
        public Order? Order { get; set; }


    }
}
