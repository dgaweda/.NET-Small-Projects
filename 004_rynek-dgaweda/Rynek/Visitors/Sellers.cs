
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rynek
{
    public class Sellers
    {
        public List<Seller> sellers = new List<Seller>();
        public void Attach(Seller seller)
        {
            sellers.Add(seller);
        }
        
        public void Detach(Seller seller)
        {
            sellers.Remove(seller);
        }
        
        public void Accept(IVisitor visitor)
        {
            foreach (Seller seller in sellers)
            {
                seller.Accept(visitor);
            }
        }
    }
}
