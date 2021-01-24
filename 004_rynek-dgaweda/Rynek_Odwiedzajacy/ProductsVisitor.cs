using Rynek_Odwiedzajacy.Products;
using Rynek_Odwiedzajacy.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitor.ActionsOfVisitor
{
    public class ProductsVisitor
    {
        private List<Product> _products = new List<Product>();

        //Bread bread = new Bread("Bulka", 0.30);
        //Fruit fruit = new Fruit("Jablko", 2.00, 10, default);
        //Sweets sweet = new Sweets("Czekolada", 2);
        //Vegetable vegetable = new Vegetable("Marchew", 1.30, 5, default);

        public void Attach(Product product)
        {
            _products.Add(product);
        }

        public void Detach(Product product)
        {
            _products.Remove(product);
        }

        public void Accept(IProductVisitor visitor)
        {
            foreach (Product product in _products)
            {
                product.Accept(visitor);
            }
        }
    }
}
