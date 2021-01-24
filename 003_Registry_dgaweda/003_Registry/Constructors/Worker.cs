using System;

namespace Registry
{
    public abstract class Worker : IWorker
    {
        Random rand = new Random();
        public string ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }

        public Address address { get; set; } // Address
        public abstract int CorpoValue();

        public Worker(string ID, string Name, string LastName, int Age,int Experience, Address address)
        {
            this.ID = string.Concat(Name[0], Name[1], LastName[0], LastName[1], (rand.Next(100000, 999999)).ToString());
            this.Name = Name;
            this.LastName = LastName;
            this.Age = Age;
            this.Experience = Experience;
            this.address = address;
        }
        public override string ToString() => String.Format("\n-ID: {0} \n-Name: {1} \n-LastName: {2} \n-Age: {3} \n-Experience: {4} {5}", ID, Name, LastName, Age, Experience, address);

    }
}
