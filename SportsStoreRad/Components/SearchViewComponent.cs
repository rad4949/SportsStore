﻿using Microsoft.AspNetCore.Mvc;
using SportsStoreRad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreRad.Components
{
    public class SearchViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new ProductListViewModel());
        }
    }
}
