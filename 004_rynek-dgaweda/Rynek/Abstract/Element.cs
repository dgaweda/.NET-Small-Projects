
using System;
using System.Collections.Generic;
using System.Text;

namespace Rynek
{
    public abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }
}
