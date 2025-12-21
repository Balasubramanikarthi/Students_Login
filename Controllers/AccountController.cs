using Microsoft.AspNetCore.Mvc;
using Students_Login.Data;
using Students_Login.Models;
using System.Linq;

namespace SimpleLoginApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var result = _context.Users
                .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (result != null)
            {
                return RedirectToAction("Welcome");
            }

            ViewBag.Message = "Invalid Username or Password";
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }
    }
}
