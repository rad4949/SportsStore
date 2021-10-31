using Microsoft.AspNetCore.Mvc;
using SportsStoreRad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //ViewBag.SelectedCategory = RouteData?.Values.ToString();
            var temp = RouteData?.Values["category"];
            return View(repository.Products.Select(x => x.Category)
                .Distinct().OrderBy(x => x));
        }       
    }
}
