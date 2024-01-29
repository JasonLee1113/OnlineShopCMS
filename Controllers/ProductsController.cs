using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using OnlineShopCMS.Data;
using OnlineShopCMS.Models;

namespace OnlineShopCMS.Controllers
{
	public class ProductsController : Controller
	{
		private readonly OnlineShopContext _context;

		public ProductsController(OnlineShopContext context)
		{
			_context = context;
		}

		// GET: Products
		//public async Task<IActionResult> Index(string searchString, string currentFilter, int? pageNumber)
		//{
		//    if (searchString != null)
		//    {
		//        pageNumber = 1;
		//    }
		//    else
		//    {
		//        searchString = currentFilter;
		//    }
		//    ViewData["CurrentFilter"] = searchString;  // 儲存當前搜尋狀態

		//    var result = from m in _context.Product select m;

		//    if (!string.IsNullOrEmpty(searchString))
		//    {
		//        result = result.Where(s => s.Name.Contains(searchString));
		//    }

		//    int pageSize = 5;  //一頁顯示幾項
		//    return View(await PaginatedList<Product>.CreateAsync(
		//        result.Include(p => p.Category).AsNoTracking(), pageNumber ?? 1, pageSize)
		//    );
		//}

		public IActionResult Index(int? cId)
		{
			List<DetailViewModel> dvm = new List<DetailViewModel>();
			List<Product> products = new List<Product>();

			//判斷如果有傳入類別編號，就篩選那個類別的商品出來
			if (cId != null)
			{
				var result = _context.Category.Single(x => x.Id.Equals(cId));
				products = _context.Entry(result).Collection(x => x.Products).Query().ToList();
			}
			else
			{
				products = _context.Product.Include(p => p.Category).ToList();
			}

			//把取出來的資料加入ViewModel  
			foreach (var product in products)
			{
				DetailViewModel item = new DetailViewModel
				{
					product = product,
					imgsrc = ViewImage(product.Image)
				};
				dvm.Add(item);
			}
			ViewBag.count = dvm.Count;

			return View(dvm);
		}

		// GET: Products/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			DetailViewModel dvm = new DetailViewModel();

            //var product = await _context.Product.Include(p => p.Category)
            //	.FirstOrDefaultAsync(m => m.Id == id);

            var product = await _context.Product.Include(c => c.Comments)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
			{
				return NotFound();
			}
			else
			{
				dvm.product = product;
				if (product.Image != null)
				{
					dvm.imgsrc = ViewImage(product.Image);
				}
			}

			return View(dvm);
		}

		private string ViewImage(byte[] arrayImage)
		{
			//二進位圖檔轉字串
			string base64String = Convert.ToBase64String(arrayImage, 0, arrayImage.Length);
			return "data:image/png;base64," + base64String;
		}

		// GET: Products/Create
		public IActionResult Create()
		{
			ViewData["Categories"] = new SelectList(_context.Set<Category>(), "Id", "Name");
			return View();

		}

		// POST: Products/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Product product, IFormFile myimg)
		{
			if (!ModelState.IsValid)
			{
				if (myimg != null)
				{
					using (var ms = new MemoryStream())
					{
						myimg.CopyTo(ms);
						product.Image = ms.ToArray();
					}
				}
				_context.Add(product);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["Categories"] = new SelectList(
				_context.Set<Category>(), "Id", "Name", product.CategoryId);
			return View(product);
		}

		// GET: Products/Edit/5
		[HttpGet]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			DetailViewModel dvm = new DetailViewModel();

			var product = await _context.Product.Include(p => p.Category)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (product == null)
			{
				return NotFound();
			}
			else
			{
				dvm.product = product;
				if (product.Image != null)
				{
					dvm.imgsrc = ViewImage(product.Image);
				}
			}

			ViewData["Categories"] = new SelectList(
			  _context.Set<Category>(), "Id", "Name", product.CategoryId);

			return View(dvm);
		}

		// POST: Products/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Product product, IFormFile myimg)
		{
			if (!ModelState.IsValid)
			{
				if (myimg != null)
				{
					using (var ms = new MemoryStream())
					{
						myimg.CopyTo(ms);
						product.Image = ms.ToArray();
					}
				}
				_context.Add(product);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["Categories"] = new SelectList(
				_context.Set<Category>(), "Id", "Name", product.CategoryId);
			return View(product);
		}


		// GET: Products/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = await _context.Product
				.FirstOrDefaultAsync(m => m.Id == id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// POST: Products/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var product = await _context.Product.FindAsync(id);
			if (product != null)
			{
				_context.Product.Remove(product);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ProductExists(int id)
		{
			return _context.Product.Any(e => e.Id == id);
		}

		public IActionResult CreateCategory()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(Category category)
		{
			_context.Category.Add(category);
			await _context.SaveChangesAsync();
			return View();
		}

		[HttpPost]
		//[Authorize]         //登入才能留言
		public async Task<IActionResult> AddComment(int Id, string myComment)
		{
			var comment = new Comment()
			{
				ProductID = Id,
				Content = myComment,
				UserName = HttpContext.User.Identity.Name,
				Time = DateTime.Now
			};
			_context.Add(comment);
			await _context.SaveChangesAsync();
			return RedirectToAction("Details", new { id = Id });
		}

	}
}


