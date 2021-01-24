using Rynek_Odwiedzajacy.Visitors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rynek_Odwiedzajacy.Products
{
    public abstract class Product
    {
        public string name { get; set; }
        public double Price { get; set; }
        public Product(string name, double Price)
        {
            this.name = name;
            this.Price = Price * AverageProductionCost();
        }
        public abstract void Accept(IProductVisitor visitor);
        public override string ToString() => String.Format("Name: {0} \nPrice: {1}", name, Price);

        public abstract double AverageProductionCost();
    }
}
