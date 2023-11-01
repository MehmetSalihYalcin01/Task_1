using Microsoft.AspNetCore.Mvc;
using Task_1.Concrete;
using Task_1.Models;

namespace Task_1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CategoryController : ControllerBase
	{
		private readonly Context c;

		public CategoryController(Context context)
		{
			c = context;
		}


		[HttpGet]
		public List<Category> GetAll()
		{
			return c.Category.ToList();
		}
		

		[HttpPost]
		public IActionResult Add(Category category)
		{

			c.Category.Add(category);
			c.SaveChanges();

			return Ok("Category Added");
		}

		[HttpGet("{id}")]
		public IActionResult GetById(Guid id)
		{
			var getid = c.Category.FirstOrDefault(x => x.Id == id);
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
				var getid = c.Category.FirstOrDefault(x => x.Id == id);

				if (getid != null)
				{
					c.Category.Remove(getid);
				c.SaveChanges();
				return Ok("Category Deleted");
				}
				else
				{
					return Ok("Category Not Found");
				}
		}

		[HttpPut("{id}")]
		public IActionResult UpdateById(Guid id ,Category category)
		{
			var getid = c.Category.FirstOrDefault(x => x.Id == id);

			if (getid == null)
			{
				return Ok("Category Not Found");
			}

			// Güncellenen verileri mevcut kategoriye uygula.
			getid.Name = category.Name;
			getid.Description = category.Description;

			c.Category.Update(getid);
			c.SaveChanges();
			return Ok("Category Updated");
		}

		[HttpGet("Id")]
		public IEnumerable<Product> GetProductWithCategory(Guid Id)
		{
			var request = c.Products.ToList();
			var getAll = request.Where(x => x.Category.Id == Id);
			return request.ToList();
		}




	}
}
