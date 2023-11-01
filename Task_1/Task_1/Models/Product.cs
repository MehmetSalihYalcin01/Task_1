using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Task_1.Models
{
	public class Product
	{
		public Product()
		{
			Id = Guid.NewGuid();
		}

		[Key]
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
        public double Price { get; set; }

        public Guid Category_ID { get; set; }
        public Category Category { get; set; }
	}
}
