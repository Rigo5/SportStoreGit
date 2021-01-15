using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;

namespace SportSore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository productRepository)
        {
            repository = productRepository;
        }
        // GET: Nav
        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = repository.Products.
                Select(p => p.Category).Distinct().OrderBy( x => x);

            //ritorniamo un view parziale che e' la view Menu 
            return PartialView(categories);
        }
    }
}