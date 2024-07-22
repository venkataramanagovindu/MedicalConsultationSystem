using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using MedicalConsultationSystem.Data;
using MedicalConsultationSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalConsultationSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly MedicalConsultationContext _context;
        public LoginController(MedicalConsultationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("username,password")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                var loggedInUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.username == user.username && u.password == user.password);

                if (loggedInUser != null)
                {
                    // Create claims and sign in the user
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.username)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    // Set session value
                    HttpContext.Session.SetString("IsLoggedIn", "true");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View("Index", user);
                }
            }
            return View("Index", user);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("IsLoggedIn");
            return RedirectToAction(nameof(Index));
        }
    }
}
