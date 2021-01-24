using System;
using System.Collections.Generic;
using System.Text;

namespace FakturaVAT
{
    class FVlist
    {
        string name;
        int amount;
        double netto_price;
        public double netto_price_x_amount
        {
            get => netto_price * amount;
            set => Math.Round(netto_price, 2);
        }

        public double TAX
        {
            get => 0.23;
        }

        public double brutto_price
        {
            get => (netto_price * TAX) + netto_price;
            set => Math.Round(brutto_price, 2);
        }

        public FVlist(string name, int amount, double netto_price, double TAX, double netto_price_x_amount, double brutto_price)
        {
            this.name = name;
            this.amount = amount;
            this.netto_price = netto_price;
        }
    }
 
}
