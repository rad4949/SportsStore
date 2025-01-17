﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportsStoreRad.Models;
using SportsStoreRad.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreRad.Controllers
{
    public class HomeController : Controller
    {    
      
        public IActionResult Index()
        {
            return View();
        }


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Error(string str)
        {
            return View(str);
        }
    }
}
