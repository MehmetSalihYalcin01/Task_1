using Microsoft.AspNetCore.Mvc;
using Task_1.Concrete;
using Task_1.Models;

namespace Task_1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : Controller
	{
		private readonly Context c;

		public ProductController(Context context)
		{
			c = context;
		}

		[HttpGet]
		public List<Product> GetAll()
		{
			var request = c.Products.ToList();
			return request;
		}

		[HttpPost]
		public IActionResult Add(Product product)
		{
			product.Id = Guid.NewGuid();
			c.Products.Add(product);
			c.SaveChanges();
			return Ok("Category Added");
		}

		[HttpGet("{id}")]
		public IActionResult GetById(Guid id)
		{
			var getid = c.Products.FirstOrDefault(x => x.Id == id);
			if (getid != null)
			{
				return Ok(getid);
			}
			else
			{
				return Ok("Category Not Found");
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteById(Guid id)
		{
			var getid = c.Products.FirstOrDefault(x => x.Id == id);

			if (getid != null)
			{
				c.Products.Remove(getid);
				c.SaveChanges();
				return Ok("Category Deleted");
			}
			else
			{
				return Ok("Category Not Found");
			}
		}

		[HttpPut("{id}")]
		public IActionResult UpdateById(Guid id, Product product)
		{
			var getid = c.Products.FirstOrDefault(x => x.Id == id);

			if (getid == null)
			{
				return Ok("Category Not Found");
			}

			// Güncellenen verileri mevcut kategoriye uygula.
			getid.Name = product.Name;
			getid.Description = product.Description;
			c.Products.Update(getid);
			c.SaveChanges();
			return Ok("Category Updated");
		}

		[HttpGet("{ID}")]
		public List<Product> GetProductByCategory(Guid ID)
		{
			return c.Products.Where(x => x.Category.Id == ID).ToList();
		}
	}
}
