using SportsStoreRad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreRad.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public Filter Filter { get; set; }
        public string CurrentCategory { get; set; }
    }
    public class Filter
    {
        public string Name { get; set; }
    }

}
