﻿using Microsoft.AspNetCore.Mvc;
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

        public ViewResult List(string category, string brand,
            Filter filter, int priceMin = -1, int priceMax = -1, int page = 1)
        {
            filter.CurrentCategory = category;
            filter.CurrentBrand = brand;
            filter.CurrentPriceMin = priceMin;
            filter.CurrentPriceMax = priceMax;
            ProductListViewModel model = new ProductListViewModel();
            var query = repository.Products.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.Brand.ToLower().Contains(filter.Name.ToLower()) ||
                x.Title.ToLower().Contains(filter.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(category))
            {
                if (category != "Всі")
                {
                    query = query.Where(p => category == null || p.Category == category);
                }
            }
            if (!string.IsNullOrEmpty(brand))
            {
                if (brand != "Всі")
                {
                    query = query.Where(p => brand == null || p.Brand == brand);
                }
            }
            if (priceMin != -1)
            {
                query = query.Where(p => p.Price >= priceMin);
            }
            if (priceMax != -1)
            {
                query = query.Where(p => p.Price <= priceMax);
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
            model.Filter = new Filter();

            model.Filter.Name = filter.Name;
            model.Filter.CurrentPriceMin = filter.CurrentPriceMin;
            model.Filter.CurrentPriceMax = filter.CurrentPriceMax;
            model.Filter.CurrentBrand = filter.CurrentBrand;
            model.Filter.CurrentCategory = filter.CurrentCategory;

            return View(model);
        }
    }
}
