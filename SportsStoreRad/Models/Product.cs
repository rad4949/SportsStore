using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreRad.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Display(Name = "Ім'я")]
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        [Display(Name = "Опис")]
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [Display(Name = "Ціна")]
        public decimal Price { get; set; }

        [Display(Name = "Категорія")]
        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }

        [Display(Name = "Фото")]
        [Required(ErrorMessage = "Please enter URL")]
        public string Img { get; set; }
    }
}
