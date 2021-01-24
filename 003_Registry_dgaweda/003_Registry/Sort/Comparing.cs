using System.Collections.Generic;
using System.Linq;

namespace Registry
{
    public class Comparing 
    {
        private static Address address1 =
            new Address("Trzy Lipy", 29, 9, "Gdansk");

        private static Address address2 =
            new Address("Jesienna", 56, 21, "Warszawa");

        private static Address address3 =
            new Address("Jagiellonki", 190, 1, "Krakow");

        private Trader _trader =
            new Trader(default, "XXX", "XXX", 21, 3, address1, Trader.EfficiencyValue.SREDNIA, 21);

        private ManualWorker _manualWorker =
            new ManualWorker(default, "AAA", "BBB", 34, 5, address2, 90);

        private BureauWorker _bureauWorker =
            new BureauWorker(default, "CCC", "EEE", 54, 10, address3, 130, default);

        Actions actions = new Actions();

        /*public List<Worker> SortedWorkers() // List<Worker> employees could be
        {
            actions.AddWorker(_manualWorker);
            actions.AddWorker(_trader);
            actions.AddWorker(_bureauWorker);

            List<Worker> workers = actions.ShowWorkers();
            workers = workers.OrderByDescending(field => field.Experience)  // employees
                    .ThenBy(field => field.Age)
                    .ThenBy(field => field.LastName)
                    .ToList();
                       
            return workers;
        }
        */
        public List<Worker> SortedWorkers()
        {
            actions.AddWorker(_manualWorker);
            actions.AddWorker(_trader);
            actions.AddWorker(_bureauWorker);


            List<Worker> workers = actions.ShowWorkers();
            var orderBy = from worker in workers
                          orderby worker.Experience, worker.Age, worker.LastName
                          select worker;

            return workers;
        }
    }
}
