﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace MedicalConsultationSystem.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
