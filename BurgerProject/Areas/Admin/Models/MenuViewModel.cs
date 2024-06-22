using BurgerProject.Data.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace BurgerProject.Areas.Admin.Models
{
	public class MenuViewModel
	{
		public string MenuName { get; set; }
		public double MenuPrice { get; set; }

		public string? ImageName { get; set; }
		public IFormFile? ImageFile { get; set; }

		



	}
}
