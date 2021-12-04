using Microsoft.AspNetCore.Mvc;
using SportsStoreRad.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStoreRad.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SportsStoreRad.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;

        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            //ViewBag.SelectedCategory = RouteData?.Values["category"];
            //return View(repository.Products.Select(x => x.Category)
            //    .Distinct().OrderBy(x => x));

            //List<Filter> ListCategory = new List<Filter>();
            //var categorys = repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);
            //foreach (string item in categorys)
            //{
            //    Filter element = new Filter();
            //    element.CurrentCategory = item;
            //    ListCategory.Add(element);
            //}
            //return View(ListCategory);

            ProductListViewModel ListCategory = new ProductListViewModel();
            var categorys = repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);

            foreach (string item in categorys)
            {
                Filter element = new Filter();
                element.CurrentCategory = item;
            }
            List<string> CategoryList = new List<string>();
            CategoryList.Add("Всі");
            foreach (string item in categorys)
            {
                CategoryList.Add(item);
            }
            ListCategory.Categories = new SelectList(CategoryList);

            return View(ListCategory);

        }
    }
}
