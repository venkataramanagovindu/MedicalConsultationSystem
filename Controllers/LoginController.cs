using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalConsultationSystem.Data;
using MedicalConsultationSystem.Models;
using Microsoft.AspNetCore.Authorization;
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
                    // Login successful, redirect to the home page
                    HttpContext.Session.SetString("IsLoggedIn", "true");
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    // Login failed, show error message
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View("Index", user);
                }
            }
            return View("Index", user);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsLoggedIn");
            return RedirectToAction(nameof(Index));
        }
    }
}
