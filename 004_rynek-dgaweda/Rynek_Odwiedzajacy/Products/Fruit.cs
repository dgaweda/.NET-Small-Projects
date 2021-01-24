using Rynek_Odwiedzajacy.Visitors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rynek_Odwiedzajacy.Products
{
    public class Fruit : Product
    {
        public double PricePerKg { get; set; }
        public int Weight { get; set; }
        public Fruit(string name, double Price, double PricePerKg, int Weight) : base(name, Price)
        {
            this.PricePerKg = PricePerKg;
            this.Weight = Weight;
            this.Price = PricePerKg * Weight * AverageProductionCost();
        }

        public override void Accept(IProductVisitor visitor) => visitor.Visit(this);

        public override double AverageProductionCost() => 1.20;
        public override string ToString() => String.Format("{0} \nPricePerKg: {1}\nWeight: {2}", base.ToString(), PricePerKg, Weight, Price);
    }
}
