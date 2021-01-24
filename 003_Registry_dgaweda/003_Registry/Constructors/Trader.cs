using System;
using System.Collections.Generic;
using System.Text;

namespace Registry
{
    public class Trader : Worker, ITrader
    {
        private EfficiencyValue _efficiency;
        private int _provision;
        public EfficiencyValue Efficiency
        {
            get => _efficiency;
            set => _efficiency = value;
        }
        public int Provision
        {
            get => _provision;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                else
                    _provision = value;
            }
        }

        public Trader(string ID, string Name, string LastName, int Age, int Experience, Address address, EfficiencyValue Efficiency, int Provision)
            :base(ID, Name, LastName, Age, Experience, address)
        {
            this.Efficiency = Efficiency;
            this.Provision = Provision;
        }

        public override string ToString() => String.Format("{0} \n-Efficiency {1} \n-Provision {2}",base.ToString(), Efficiency, Provision);

        public override int CorpoValue() => Experience * (int)Efficiency;

        public enum EfficiencyValue
        { 
            NISKA = 60,
            SREDNIA = 90,
            WYSOKA = 120
        }
    }
}
