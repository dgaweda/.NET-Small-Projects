
using System;
using System.Collections.Generic;
using System.Text;

namespace Rynek
{
    public class Accessories
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double ProductionCost { get; set; }
        public Accessories(string name, double Price, double ProductionCost)
        {
            this.Name = name;
            this.ProductionCost = ProductionCost;
            this.Price = Price + ProductionCost;    
        }
    }
}
