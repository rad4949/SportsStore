using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SportsStoreRad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStoreRad.Infrastructure;
using SportsStoreRad.ViewModels;

namespace SportsStoreRad.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart cart;

        public CartController(IProductRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        public IActionResult Index(string returnUrl)
        {          
            CartIndexViewModel model = new CartIndexViewModel();
            model.Cart = cart;
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId=0, string returnUrl="")
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItemEvent += cart.AddItem;
                cart.AddElementInCartLine(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public delegate RedirectToActionResult DLRemoveFromCart(int productId, string returnUrl);
        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            DLRemoveFromCart dLRemoveFromCart = delegate
            {
                Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

                if (product != null)
                {
                    cart.RemoveLine(product);
                }
                return RedirectToAction("Index", new { returnUrl });
            };
            dLRemoveFromCart(productId, returnUrl);
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
