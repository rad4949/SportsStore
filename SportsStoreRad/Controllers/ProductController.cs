using Microsoft.AspNetCore.Mvc;
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
        public int PageSize = 3;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(Filter filter, string category, int productPage = 1)
        {
            ProductListViewModel model = new ProductListViewModel();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                model.Products = repository.Products.Where(p => category == null || p.Category == category)
               .OrderBy(p => p.ProductID)
               .Skip((productPage - 1) * PageSize)
               .Take(PageSize);

                int tempTotalItems;
                if((category == null) && (filter.Name == null))
                {
                    tempTotalItems = repository.Products.Count();
                }
                else if((category == null) && (filter.Name != null))
                {
                    tempTotalItems = repository.Products.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower())).Count();
                }
                else if((category != null) && (filter.Name == null))
                {
                    tempTotalItems = repository.Products.Where(e => e.Category == category).Count();
                }
                else
                {
                    tempTotalItems = repository.Products.Count();
                }
                model.PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = tempTotalItems
                };
            }
            else
            {
                model.Products = repository.Products.Where(p => category == null || p.Category == category)
               .OrderBy(p => p.ProductID)
               .Skip((productPage - 1) * PageSize)
               .Take(PageSize);

                model.PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(e => e.Category == category).Count()
                };
            }

            model.Filter = filter;
            model.CurrentCategory = category;

            return View(model);
        }
    }
}
