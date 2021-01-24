using Rynek_Odwiedzajacy.Visitors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rynek_Odwiedzajacy.Products
{
    public class Bread : Product
    {
        public Bread(string name, double Price): base(name, Price)
        {
        }
        public override void Accept(IProductVisitor visitor) => visitor.Visit(this);

        public override double AverageProductionCost() => 1.30;
        public override string ToString() => String.Format("{0} \nPrice: {1}\n", base.ToString(), Price);

       
    }
}
