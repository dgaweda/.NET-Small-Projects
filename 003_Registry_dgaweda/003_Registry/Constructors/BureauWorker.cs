using System;

namespace Registry
{
    public class BureauWorker : Worker, IBureauWorker 
    {
        Random rand = new Random();
        public string BureauWorkerID { get; set; }

        public int IQ { get; set; }

        public BureauWorker(string ID, string Name, string LastName, int Age, int Experience, Address address, int IQ, string BureauWorkerID)
            : base(ID, Name, LastName, Age, Experience, address)
        {
            this.IQ = IQ;
            this.BureauWorkerID = String.Concat(LastName[0], Name[0], LastName[1], Name[1], rand.Next(1000, 9999));
        }
        
        public override string ToString() => String.Format("{0} \n-BureauID {1} \n-IQ {2}", base.ToString(), BureauWorkerID, IQ);

        public override int CorpoValue() => IQ * Experience;
    }
}
