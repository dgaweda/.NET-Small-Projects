using Rynek_Odwiedzajacy.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rynek_Odwiedzajacy.Visitors
{
    public interface IProductVisitor
    {
        double Visit(Bread bread);
        double Visit(Fruit fruit);
        double Visit(Sweets sweets);
        double Visit(Vegetable vegetable);

    }
}
