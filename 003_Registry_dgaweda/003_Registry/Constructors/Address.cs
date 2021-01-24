using System;

namespace Registry
{
    public class Address : IAddress
    {
        public string StreetName { get; set; }
        public int Building { get; set; }
        public int Local { get; set; }
        public string City { get; set; }

        public Address(string StreetName, int Building, int Local, string City)
        {
            this.StreetName = StreetName;
            this.Building = Building;
            this.Local = Local;
            this.City = City;
        }
        public override string ToString() => String.Format("\n-Ulica: {0} \n-Budynek: {1} \n-Lokal: {2} \n-Miasto: {3}", StreetName, Building, Local, City);

    }
}
