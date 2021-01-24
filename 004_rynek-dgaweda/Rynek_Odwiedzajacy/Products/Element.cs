using Rynek_Odwiedzajacy.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor.Products
{
    public abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }
}
