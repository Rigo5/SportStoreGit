using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entity;
using System.Web.Mvc;
using SportSore.WebUI.Models;

namespace SportSore.WebUI.Controllers
{
    public class CartController : Controller
    {
        //IProductRepository
        public IProductRepository repository;

        public CartController(IProductRepository productRepository)
        {
            repository = productRepository;
        }
        //Action method che ritorna la vista Index
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartViewModel { Cart = cart, ReturnUrl = returnUrl });
        }
        //gli passiamo anche l url dove tornare 
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if(product != null)
            {
                //Prendiamo il Cart dalla sessione 
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl});
        }
        //Remove product from chart
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            
            if(product != null)
            {
                cart.RemoveProduct(product);
            }
            //reindirizza il browser al nuovo URL che chiamera l'index action method 
            return RedirectToAction("Index", new { returnUrl });
        }
        //Pratial view for inject the summary 
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}