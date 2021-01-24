using NUnit.Framework;
using Registry;
using System.Linq;

namespace RegistryTests
{
    [TestFixture]
    public class Tests
    {

        private Actions actions = new Actions();
        private static Address address1 =
            new Address("Trzy Lipy", 29, 9, "Krakow");

        private static Address address2 =
            new Address("Jesienna", 56, 21, "Gdansk");

        private static Address address3 =
            new Address("Jagiellonki", 190, 1, "Gdansk");

        private Trader _trader = 
            new Trader(default, "XXX", "XXX", 21, 3, address1, Trader.EfficiencyValue.SREDNIA, 21);

        private BureauWorker _bureauWorker =
            new BureauWorker(default, "CCC", "EEE", 54, 10, address3, 130, default);

        [Test]
        public void CheckIfTestWorks()
        {
            Assert.Pass();
        }

        [Test]
        public void CheckIfAddWorkerWorks()
        {
            actions.AddWorker(_bureauWorker);
            actions.AddWorker(_trader);

            Assert.AreEqual(actions.ShowWorkers().Count, 2);
        }

        [Test]
        public void CheckIfShowingWorkerByCityWorks()
        {
            var result = actions.ShowByCity("Gdansk").First();
            Assert.AreEqual(result, _bureauWorker);
        }

        [Test]
        public void CheckIfRemovingWorks()
        {
            actions.RemoveWorker("XX");
            var result = actions.ShowWorkers().First();

            Assert.AreEqual(result, _bureauWorker);
        }

        [Test]
        public void CheckIfCorpoValueIsCorrect()
        {
            var result = actions.CheckValue(_bureauWorker);
            Assert.AreEqual(result, 1300);
        }
    }
}