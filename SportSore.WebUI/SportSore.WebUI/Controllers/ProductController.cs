using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entity;

namespace SportSore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository Repository;
        const int PageSize = 3;
        //Dependencyy declared
        public ProductController(IProductRepository productRepository)
        {
            this.Repository = productRepository;
        }
        //parametri passati nella request come query string parameters 
        public ViewResult List(string category, int page = 1)
        {
            Models.ProductsListViewModel model = new Models.ProductsListViewModel()
            {
                Products = Repository.Products.
                                Where((p) => (category == null || p.Category == category)).
                                OrderBy((p) => p.ProductID).
                                Skip((page - 1) * PageSize).
                                Take(PageSize),
                Page = new Models.PageInfo()
                {
                    CurrentPage = page,
                    ItemPerPage = PageSize,
                    TotalItems = category == null ?
                        Repository.Products.Count():
                        Repository.Products.Where( p => p.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

    }
}