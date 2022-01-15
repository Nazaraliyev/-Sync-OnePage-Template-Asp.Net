using Microsoft.AspNetCore.Mvc;

namespace Sync_OnePage_Template_Asp.Net.Areas.admin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }
    }
}
