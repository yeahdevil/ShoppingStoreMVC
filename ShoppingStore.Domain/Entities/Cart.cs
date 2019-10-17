using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> linecollection = new List<CartLine>();
        public void AddItem(Product product,int quantity)
        {
            CartLine line = linecollection.Where(p => p.Product.ProductId == product.ProductId)
                .FirstOrDefault();
            if (line == null)
            {
                linecollection.Add(new CartLine { Product = product, Quantity = quantity })
;            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Product product)
        {
            linecollection.RemoveAll(p => p.Product.ProductId == product.ProductId);
        }
        public decimal ComputeTotalValue()
        {
            return linecollection.Sum(p => p.Product.Price * p.Quantity);
        }
        public IEnumerable<CartLine> Lines
        {
            get { return linecollection; }
        }
        public void Clear()
        {
            linecollection.Clear();
        }
       
    }
}
