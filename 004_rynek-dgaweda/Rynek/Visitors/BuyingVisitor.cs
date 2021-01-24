using System;
using System.Collections.Generic;
using System.Text;

namespace Rynek
{
    public class BuyingVisitor : IVisitor
    {
        public string Accessory { get; set; }
        public BuyingVisitor(string Accessory)
        {
            this.Accessory = Accessory;
        }

        public void Visit(Element element)
        {
            Seller seller = element as Seller;

            if (seller.accessory.Name.Equals(Accessory))
            {
                Console.WriteLine("{0} Had been bought for {1}$", seller.accessory.Name, seller.FinalPrice);
                seller.Amount--;
            }
        }
    }
}
