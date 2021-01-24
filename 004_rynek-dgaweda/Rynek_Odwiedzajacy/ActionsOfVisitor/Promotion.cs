using Rynek_Odwiedzajacy.Products;
using System;
using System.Collections.Generic;
using System.Text;
using Visitor.Products;
using Rynek.Subscribers;

namespace Rynek_Odwiedzajacy.Visitors
{
    public class Promotion : IProductVisitor
    {
        public double promotion { get; set; }
        
        public Promotion(double promotion)
        {
            this.promotion = (100 - promotion)/100 ;
        }

        public double Visit(Element element)
        {
            Seller seller = element as Seller;
            Console.WriteLine("Cena {0} normalnie : {1}", bread.name, bread.Price);
            double price = Math.Round(bread.Price * promotion, 2);
            Console.WriteLine("Cena {0} na promocji : {1}", bread.name, price);
            return price;
        }

        public double Visit(Fruit fruit) => Math.Round(fruit.PricePerKg * promotion, 2);

        public double Visit(Sweets sweets) => Math.Round(sweets.Price * promotion, 2);

        public double Visit(Vegetable vegetable) => Math.Round(vegetable.PricePerKg * promotion, 2);
    }
}
