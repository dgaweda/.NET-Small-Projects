using System;
using System.Collections.Generic;

namespace Registry
{
    class RegistryMain
    {
        private static Address address1 =
            new Address("Trzy Lipy", 29, 9, "Gdansk");

        private static Address address2 =
            new Address("Jesienna", 56, 21, "Warszawa");

        private static Address address3 =
            new Address("Jagiellonki", 190, 1, "Krakow");

        private static Trader _trader =
            new Trader(default, "XXX", "XXX", 21, 3, address1, Trader.EfficiencyValue.SREDNIA, 21);

        private static ManualWorker _manualWorker =
            new ManualWorker(default, "AAA", "BBB", 34, 5, address2, 90);

        private static BureauWorker _bureauWorker =
            new BureauWorker(default, "CCC", "EEE", 54, 10, address3, 130, default);
        
        static Actions _actions = new Actions();
        static void Main()
        {
            
            
            Comparing _compare = new Comparing();
            List<Worker> _workers = _actions.ShowWorkers();

            //ADDING SOME EXAMPLES
            _actions.AddWorker(_trader);
            _actions.AddWorker(_bureauWorker);
            _actions.AddWorker(_manualWorker);

            //SHOW ALL WORKERS
            Console.WriteLine("\nALL WORKERS");
            ShowAll(_workers);

            // SHOW BY CITY
            Console.WriteLine("\nSHOW BY CITY");
            ShowAll(_actions.ShowByCity("Gdansk"));

            //SHOW SORTED LIST OF WORKERS
            Console.WriteLine("\nSHOW SORTED LIST");
            List<Worker> Sorted = _compare.SortedWorkers();
            ShowAll(Sorted);

            //SHOW WORKERS WITH THEIR VALUE
            Console.WriteLine("\nSHOW WORKERS WITH VALUE");
            ShowWorkersWithValue(_workers);

            //REMOVING
            Console.WriteLine("\nAFTER REMOVING");
            _actions.RemoveWorker("XX");
            ShowAll(_workers);
        }

        public static void ShowAll(List<Worker> employess)
        {
            foreach (var employee in employess)
                Console.WriteLine(employee);
        }

        public static void ShowWorkersWithValue(List<Worker> employess)
        {
            foreach (var employee in employess)
                Console.WriteLine(employee + "\n-CorporationValue: {0}", _actions.CheckValue(employee));
        }
    }
}
            