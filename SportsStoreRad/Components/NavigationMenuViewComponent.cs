using Microsoft.AspNetCore.Mvc;
using SportsStoreRad.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportsStoreRad.Components
{
    public class NavigationMenuViewComponent: ViewComponent
    {
        private IProductRepository repository;

        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products.Select(x => x.Category)
                .Distinct().OrderBy(x => x));
        }       
    }
}
