using NUnit.Framework;
using Rynek;
using System.Linq;

namespace RynekTesty
{
    [TestFixture]
    public class Tests
    {
        static Accessories monitor = new Accessories("Monitor LCD", 400.0, 100.0);

        static Seller seller = new Seller(monitor, 10, "Dariusz", "Gaweda", 1.10, default);

        static Buyer buyer = new Buyer("Artur", "Grzybowski", "Monitor LCD", 800);
        static Buyer buyer2 = new Buyer("Olga", "Rachowiak", "Telefon", 3300);

        Sellers sellers = new Sellers();
        Inflation inflation = new Inflation(5);
        Bank provider = new Bank();
        Seller provider2 = new Seller();
        [Test]
        public void CheckIfInflationHasChanged()
        {
            Assert.That(inflation.inflation, Is.EqualTo(5));
        }

        [Test]
        public void CheckIfSettingInflationChangePrices()
        {
            provider.Subscribe(seller);
            provider.SetInflation(20);
            Assert.That(seller.FinalPrice, Is.EqualTo(594));
        }
        [Test]
        public void CheckIfSubscribtionWorks()
        {
            provider.Subscribe(buyer);

            Assert.AreEqual(seller, provider.observers.First());
        }

        [Test]
        public void CheckIfSubscribingSecondObserverIncreaseCountOfList()
        {
            provider.Subscribe(buyer2);

            Assert.That(provider.observers.Count(), Is.EqualTo(2));
        }

        [Test]
        public void CheckIfSubscribingBuyerWorks()
        {
            provider2.Subscribe(buyer);

            Assert.AreEqual(provider2.observers.First(), buyer);
        }

        [Test]
        public void CheckIfSubscribingSecondObserverToSellerIncreaseCountOfTheList()
        {
            provider2.Subscribe(buyer2);

            Assert.That(provider2.observers.Count(), Is.EqualTo(2));
        }

        [Test]
        public void CheckIfSellersAttachmentWorks()
        {
            sellers.Attach(seller);

            Assert.AreEqual(seller, sellers.sellers.First());
        }

        [Test]
        public void CheckIfSellersDetachemntWorks()
        {
            sellers.Detach(seller);
            sellers.Detach(seller);
            sellers.Detach(seller);

            Assert.That(sellers.sellers.Count(), Is.EqualTo(0));
        }

        [Test]
        public void CheckIfPriceVisitorWorks()
        {
            sellers.Detach(seller);
            provider.Subscribe(seller);
            sellers.Attach(seller);
            sellers.Accept(new PriceVisitor(10, "Monitor LCD")); // Promotionfrom 550 to 495 for Monitors LCD 10%

            Assert.That(seller.FinalPrice, Is.EqualTo(495));
        }
        [Test]
        public void CheckIfBuyingVisitorWorks()
        {
            provider.Subscribe(seller);
            sellers.Attach(seller);
            sellers.Accept(new BuyingVisitor("Monitor LCD"));
            Assert.That(seller.Amount, Is.EqualTo(9));
        }

        [Test]
        public void CheckIfDisposingWorks()
        {
            var result = provider.Subscribe(seller);
            result.Dispose();
            Assert.That(provider.observers.Count(), Is.EqualTo(0));
        }
    }
}