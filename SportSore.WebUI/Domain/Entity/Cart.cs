using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Cart
    {
        private List<CartLine> Lines = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            //controllo prima se e' gia presente nel carrello 
            //o restituisce il primo o null
            CartLine line = Lines.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if(line == null)
            {
                Lines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        //totale prezzo
        public decimal GetTotal()
        {
            return Lines.Sum(p => p.Product.Price * p.Quantity);
        }
        //Clear cart
        public void ClearCart()
        {
            Lines.Clear();
        }
        //Remove line
        public void RemoveProduct(Product prodToRemove)
        {
            Lines.RemoveAll(line => line.Product.Name == prodToRemove.Name);
        }
        //Get Producs 
        public IEnumerable<CartLine> CartProducts { 
            get 
            {
                return Lines;
            } 
        }

    }
}
