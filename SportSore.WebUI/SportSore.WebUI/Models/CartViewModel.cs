using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entity;

namespace SportSore.WebUI.Models
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}