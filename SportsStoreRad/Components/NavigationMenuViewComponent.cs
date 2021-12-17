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

        public IViewComponentResult Invoke(Filter filter)
        {
            ProductListViewModel ListFilters = new ProductListViewModel();
            var categorys = repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);
            var query = repository.Products.AsQueryable();
            ListFilters.PriceNumber = new PriceNumber();
            ListFilters.PriceNumber.PriceMin = (int)(query.Min(point => point.Price));
            ListFilters.PriceNumber.PriceMax = (int)(query.Max(point => point.Price));
            ListFilters.PriceNumber.ValuePriceMax = ListFilters.PriceNumber.PriceMax;

            ListFilters.Filter = new Filter();
            ListFilters.Filter = filter;

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
            ListFilters.Categories = new SelectList(CategoryList);

            var brand = repository.Products.Select(x => x.Brand).Distinct().OrderBy(x => x);
            foreach (string item in brand)
            {
                Filter element = new Filter();
                element.CurrentBrand = item;
            }
            List<string> BrandList = new List<string>();
            BrandList.Add("Всі");
            foreach (string item in brand)
            {
                BrandList.Add(item);
            }
            ListFilters.Brands = new SelectList(BrandList);

            return View(ListFilters);
        }
    }
}
