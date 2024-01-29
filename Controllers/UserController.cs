using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopCMS.Areas.Identity.Data;

namespace OnlineShopCMS.Controllers
{
	public class UserController : Controller
	{

		private readonly RoleManager<IdentityRole> _roleManager;

		public UserController(RoleManager<IdentityRole> roleManager)
		{
			this._roleManager = roleManager; // 宣告roleManager
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult RoleCreate()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> RoleCreate(OnlineShopUserRole role)
		{
			var roleExist = await _roleManager.RoleExistsAsync(role.RoleName); //判斷角色是否已存在
			if (!roleExist)
			{
				var result = await _roleManager.CreateAsync(new IdentityRole(role.RoleName));
			}
			return View();
		}
	}
}
