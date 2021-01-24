
using System;
using System.Collections.Generic;
using System.Text;

namespace Rynek
{
    public class PriceVisitor : IVisitor
    {
        public double promotion { get; set; }
        public string Product { get; set; }
        
        public PriceVisitor(double promotion, string Product)
        {
            this.promotion = promotion ;
            this.Product = Product;
        }

        public void Visit(Element element)
        {
            Seller seller = element as Seller;
            
            if (seller.accessory.Name.Equals(Product))
            {
                //Console.WriteLine("Promotion {0}% for Monitors", promotion);
                //Console.WriteLine("Old price of {0} was {1} $", Product, seller.FinalPrice);
                seller.FinalPrice = Math.Round(seller.FinalPrice * ((100 - promotion) / 100), 2);
                //Console.WriteLine("Price after promotion: {1} $", seller.accessory.Name, seller.FinalPrice);
            }       
        }
    }
}
