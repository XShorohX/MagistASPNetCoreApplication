using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PraktASPApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
			return View();
		}
    }
}
