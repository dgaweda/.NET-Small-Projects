
using System;
using System.Collections.Generic;
using System.Text;


namespace Rynek
{
    public interface IVisitor
    {
        void Visit(Element element);
    }
}
