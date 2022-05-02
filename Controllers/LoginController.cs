using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalConsultationSystem.Data;
using MedicalConsultationSystem.Models;
using Microsoft.AspNetCore.Mvc;

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

        //public IActionResult Login([Bind("username", "password")] User user)
        //{
        //    //await _context.FindAsync();
        //}
    }
}
