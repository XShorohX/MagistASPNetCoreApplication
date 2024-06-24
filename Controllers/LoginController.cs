using PraktASPApp.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PraktASPApp.Models;

namespace PraktASPApp.Controllers
{
    public class LoginController : Controller
    {
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(LoginVM model)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				var user = (from usr in db.Users
							where usr.Login == model.Login
							where usr.Password == model.Password
							select usr).Take(1).ToList().FirstOrDefault(u => true, null);

				if (user == null)
				{
					ViewData["Message"] = "Ошибка: Невалидные данные";
					return View();
				}

				var cookieOptions = new CookieOptions
				{
					Expires = DateTime.Now.AddDays(30)
				};
				Response.Cookies.Append("Login", user.Login, cookieOptions);
				Response.Cookies.Append("Password", user.Password, cookieOptions);

				
				return RedirectToAction("Office", "Office");

			}
		}
	}
}
