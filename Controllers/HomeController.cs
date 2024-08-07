﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MedicalConsultationSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace MedicalConsultationSystem.Controllers
{
    [Authorize(Policy = "MustBeLoggedIn")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Handle form submission (e.g., send email)
                // For now, just redirect to a Thank You page or back to the Contact page
                return RedirectToAction("ContactConfirmation");
            }
            return View(model);
        }

        public IActionResult ContactConfirmation()
        {
            return View();
        }
    }
}
