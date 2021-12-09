using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsStoreRad.Models;
using SportsStoreRad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreRad.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, Filter filter, int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel();
            var query = repository.Products.AsQueryable();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(category))
            {
                if(category!="Всі")
                {
                    query = query.Where(p => category == null || p.Category == category);
                }
            }
            int pageSize = 3;
            int pageNo = page - 1;

            model.Products = query.OrderBy(x => x.ProductID)
                .Skip(pageNo * pageSize)
                .Take(pageSize)
                .ToList();

            int allCount = query.Count();

            model.Page = page;
            model.MaxPage = (int)Math.Ceiling((double)allCount / pageSize);
            model.Filter = filter;

            var categorys = repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);

            return View(model);
        }
    }
}
