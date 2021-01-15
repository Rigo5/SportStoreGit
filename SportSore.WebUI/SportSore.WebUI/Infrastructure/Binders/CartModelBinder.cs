using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entity;

namespace SportSore.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        //MVC utilizza i model binders per creare oggetti in c# da chiamate http e passare questi come
        //parametri agli action method del controller
        //obbiettivo qua e' quello di ottenere il carello dalla sessione del soggetto 
        private readonly string sessionKey = "Cart";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = null; 
            if(controllerContext.HttpContext.Session[sessionKey] != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }
            
            if(cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            return cart;
        }
    }
}