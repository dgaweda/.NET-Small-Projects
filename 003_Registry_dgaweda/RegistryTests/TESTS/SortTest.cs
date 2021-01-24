using NUnit.Framework;
using System.Collections.Generic;
using Registry;
using System.Linq;

namespace RegistryTests
{
    [TestFixture]
    public class SortTests
    {
        /*
        private Actions _actions = new Actions();
        private Comparing _sort = new Comparing();

        [Test]
        public void CheckIfTestWorks()
        {
            Assert.Pass();
        }

       /* [Test]
        public void CheckIfSortWorks()
        {
            List<Worker> Sort = _sort.SortedWorkers();
            
            var result = Sort.Select(field => field.Experience).First();
            var expected = 10;

            Assert.AreEqual(result, expected);
        }
        */
        private Actions _actions = new Actions();
        private Comparing _sort = new Comparing();
        
        private static Address address1 =
            new Address("Trzy Lipy", 29, 9, "Krakow");

        private static Address address2 =
            new Address("Jesienna", 56, 21, "Gdansk");

        private static Address address3 =
            new Address("Jagiellonki", 190, 1, "Gdansk");

        private Trader _trader =
            new Trader(default, "XXX", "XXX", 21, 3, address1, Trader.EfficiencyValue.SREDNIA, 21);

        private ManualWorker _manualWorker =
            new ManualWorker(default, "AAA", "BBB", 34, 5, address2, 90);

        private BureauWorker _bureauWorker =
            new BureauWorker(default, "CCC", "EEE", 54, 10, address3, 130, default);

        [Test]
        public void CheckIfTestWorks()
        {
            Assert.Pass();
        }
       
        [Test]
        public void CheckIfSortWorks()
        {
            _actions.AddWorker(_trader);
            _actions.AddWorker(_bureauWorker);
            _actions.AddWorker(_manualWorker);


            _sort.SortedWorkers();
        }
         
    }
}