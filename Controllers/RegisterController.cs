using PraktASPApp.Database;
using Corpa4Sem4.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PraktASPApp.Models;

namespace PraktASPApp.Controllers
{
    public class RegisterController : Controller
	{
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM model)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				var user = new User
				{
					Login = model.Login,
					FullName = model.FullName,
					Password = model.Password
				};

				if (db.Users.Any(u => u.Login == model.Login))
				{
                    ViewData["Message"] = "������ ��� �������� ������. ����������, ���������� �����.";
                    return View();
				}

				await db.Users.AddAsync(user);
				await db.SaveChangesAsync();

				return RedirectToAction("Office", "Office");

			}
		}
	}
}
