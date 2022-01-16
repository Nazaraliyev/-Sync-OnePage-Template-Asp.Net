using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sync_OnePage_Template_Asp.Net.Data;
using Sync_OnePage_Template_Asp.Net.Models;
using Sync_OnePage_Template_Asp.Net.ViewModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sync_OnePage_Template_Asp.Net.Areas.admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(AppDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
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


        public async Task<IActionResult> Delete(string Id)
        {
            if(Id != null)
            {
                if(_context.costumeUsers.Any(u => u.Id == Id))
                {
                    CostumeUser user = _context.costumeUsers.Find(Id);
                    if(user.Profile != "progile.png")
                    {
                        string oldProfile = Path.Combine("wwwroot", "assets/img/profile", user.Profile);
                        if (System.IO.File.Exists(oldProfile))
                        {
                            System.IO.File.Delete(oldProfile);
                        }
                    }

                    await _userManager.DeleteAsync(user);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult Login()
        {
            return View();
        }



    }
}
