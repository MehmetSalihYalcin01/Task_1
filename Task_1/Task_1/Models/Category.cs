using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;

namespace Task_1.Models
{
	public class Category
	{
		public Category()
		{
			Id = Guid.NewGuid();
		}

		[Key]
		public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }


		public ICollection<Product>? Products { get; }
	}
}
