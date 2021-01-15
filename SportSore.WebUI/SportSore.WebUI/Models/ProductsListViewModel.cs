using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entity;

namespace SportSore.WebUI.Models
{
    //classe che unisce PageInfo e Producs da passare nel model 
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageInfo Page { get; set; }
        public string CurrentCategory { get; set; }
    }
}