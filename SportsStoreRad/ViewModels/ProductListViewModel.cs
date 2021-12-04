using Microsoft.AspNetCore.Mvc.Rendering;
using SportsStoreRad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreRad.ViewModels
{
    public class ProductListViewModel
    {
        public int Page { get; set; }
        public int MaxPage { get; set; }
        public Filter Filter { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public SelectList Categories { get; set; }
    }
    public class Filter
    {
        public string Name { get; set; }
        public string CurrentCategory { get; set; }
    }

}
