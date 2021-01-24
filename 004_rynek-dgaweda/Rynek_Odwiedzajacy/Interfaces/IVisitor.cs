using Rynek_Odwiedzajacy.Visitors;
using System;
using System.Collections.Generic;
using System.Text;
using Visitor.Products;

namespace Rynek_Odwiedzajacy.Products
{
    public interface IVisitor
    {
        void Visit(Element element);
    }
}
