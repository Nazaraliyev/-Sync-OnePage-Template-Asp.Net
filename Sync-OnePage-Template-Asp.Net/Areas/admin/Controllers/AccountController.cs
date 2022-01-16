using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sync_OnePage_Template_Asp.Net.Data;
using Sync_OnePage_Template_Asp.Net.ViewModel;
using System.Linq;

namespace Sync_OnePage_Template_Asp.Net.Areas.admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(AppDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            ViewBag.UserRoles = _context.UserRoles.ToList();
            ViewBag.Roles = _context.Roles.ToList();
            return View(_context.costumeUsers.ToList());
        }


        public IActionResult Create()
        {
            VmUserRegister model = new VmUserRegister()
            {
                Role = _roleManager.Roles.ToList()
            };
            return View(model);
        }


        public IActionResult Login()
        {
            return View();
        }
    }
}
