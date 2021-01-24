using Rynek_Odwiedzajacy.Products;
using Rynek_Odwiedzajacy.Visitors;
using System;
using Visitor.ActionsOfVisitor;

namespace Rynek_Odwiedzajacy
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductsVisitor productList = new ProductsVisitor();
           
            productList.Attach(new Bread("Bulka", 0.30));
            productList.Attach(new Fruit("Jablko", 2.00, 10, default));
            productList.Attach(new Sweets("Czekolada", 2));
            productList.Attach(new Vegetable("Marchew", 1.30, 5, default));

            productList.Accept(new Promotion(10));
        }
    }
}
