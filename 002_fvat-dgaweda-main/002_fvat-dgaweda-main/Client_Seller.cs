using System;
using System.Collections.Generic;
using System.Text;

namespace FakturaVAT
{
    class Client_Seller
    {
        string company_name;
        string address;
        string nip;
        string account_number;
        public Client_Seller(string company_name, string address, string nip, string account_number)
        {
            this.company_name = company_name;
            this.address = address;
            this.nip = nip;
            this.account_number = account_number;
        }

    }
}
