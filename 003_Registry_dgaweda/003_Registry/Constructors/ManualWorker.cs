using System;
using System.Collections.Generic;
using System.Text;

namespace Registry
{
    public class ManualWorker : Worker, IManualWorker
    {
        private int _strength;
        public int Strength 
        {
            get => _strength;
            set
            {
                if (_strength < 0 || _strength > 100)
                    throw new ArgumentOutOfRangeException();
                else
                    _strength = value;
            }
        }
        public ManualWorker(string ID, string Name, string LastName,int Age,int Experience, Address address, int Strength )
            :base (ID, Name, LastName, Age, Experience, address)
        {
            this.Strength = Strength;
        }
        public override string ToString() => String.Format("{0} \n-Strength: {1} ",  base.ToString(), Strength);

        public override int CorpoValue() => Experience * Strength / Age;
    }
}
