
using System;
using System.Collections.Generic;
using System.Linq;

namespace FakturaVAT
{
    class FVat
    {
        public int i = -1;
        public static double brutto_price_from_WholeFV = 0;
        Client_Seller client_seller = new Client_Seller(default, default, default, default);
        FVlist FVlist = new FVlist(default,default,default,default, default, default);
       
        List<FVlist> Faktura = new List<FVlist>();
        List<Client_Seller> DaneKlientaISprzedawcy = new List<Client_Seller>();

        //FV
        public bool FvDataNull(string product_name, int amount, double price)
        {
            if (product_name == null || product_name.Equals("") || amount == null || amount.Equals("") || price == null || price.Equals(""))
                return false;
            else
                return true;
        }

        public double BruttoPrice(string product_name, int amount, double netto_price)
        {
            i++;
            Faktura.Add(new FVlist(product_name, amount, netto_price, default, default, default));
            
            return Faktura.ElementAt(i).brutto_price;
        }

        public double NettoXAmountPrice(string product_name, int amount, double netto_price)
        {
            i++;
            Faktura.Add(new FVlist(product_name, amount, netto_price, default, default, default));
            
            return Faktura.ElementAt(i).netto_price_x_amount;
        }

        public double BruttoFromWholeFV(string product_name, int amount, double netto_price) 
        {
            i++;
            Faktura.Add(new FVlist(product_name, amount, netto_price, default, default, default));

            return Math.Round((brutto_price_from_WholeFV += Faktura.ElementAt(i).brutto_price), 2);
        }
        // Dane klienta i sprzedawcy //
        public bool ClientSellerDataNull(string company_name, string address, string nip, string account_number)
        {
            DaneKlientaISprzedawcy.Add(new Client_Seller(company_name, address, nip, account_number));
            if (company_name == null    || address == null    || nip == null    || account_number == null ||
                company_name.Equals("") || address.Equals("") || nip.Equals("") || account_number.Equals(""))
                return false;
            else
                return true;
        }

        public bool NipCheck(string nip)
        {
            DaneKlientaISprzedawcy.Add(new Client_Seller(default, default, nip, default));

            if ((int)nip[3] == 45 && (int)nip[7] == 45 && (int)nip[10] == 45 && nip.Length == 13)
            {
                foreach (var character in nip)
                    if (((int)character < 48 || (int)character > 57) && (int)character != 45)
                        return false;

                return true;
            }
            return false;
        }

        public bool AccountNumberCheck(string account_number) 
        {
            DaneKlientaISprzedawcy.Add(new Client_Seller(default, default, default, account_number));

            if (account_number.Length != 26)
                return false;
            else 
                foreach (var character in account_number)
                {
                    if ((int)character  < 48 || (int)character > 57)
                        return false;
                }
            
            return true;
        }

        // Sprawdzenie formy daty //
        public bool DateOfBuyingCheck(string dateOfBuying) 
        {
            if (dateOfBuying[2].Equals('.') && dateOfBuying[5].Equals('.') && dateOfBuying.Length == 10)
            {
                foreach (var character in dateOfBuying)
                    if (((int)character < 48 || (int)character > 57) && (int)character != 46)
                        return false;

                return true;
            } 
            return false;
        }

        public bool DateOfSellingCheck(string dateOfSelling) 
        {
            if (dateOfSelling[2].Equals('.') && dateOfSelling[5].Equals('.') && dateOfSelling.Length == 10)
            {
                foreach (var character in dateOfSelling)
                    if (((int)character < 48 || (int)character > 57) && ((int)character != 46))
                        return false;

                return true;
            }
            return false;
        }

        public bool DateOfMakingFVCheck(string dateOfMakingFV)
        {
            if (dateOfMakingFV[2].Equals('.') && dateOfMakingFV[5].Equals('.') && dateOfMakingFV.Length == 10)
            {
                foreach (var character in dateOfMakingFV)
                    if (((int)character < 48 || (int)character > 57) && ((int)character != 46))
                        return false;

                return true;
            }
            return false;
        }
    }
}