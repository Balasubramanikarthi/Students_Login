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
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // Pass success flag to the view
                ViewBag.LoginSuccess = true;
                return View(); // Stay on login view to show popup
            }

            ViewBag.Error = "Login Failed! Invalid username or password.";
            return View();
        }


    }
}
