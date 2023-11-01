using Microsoft.EntityFrameworkCore;
using Task_1.Models;

namespace Task_1.Concrete
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		public DbSet<Category> Category { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
