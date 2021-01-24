using FakturaVAT;
using NUnit.Framework;

namespace FVat_Tests
{
    class FVatTest
    {
        private FVat _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new FVat();
        }

        [Test]
        public void CheckIfTestWorks()
        {
            Assert.Pass();
        }

        [Test]
        public void CheckIfCanCreateSut()
        {
            Assert.That(_sut, Is.Not.Null);
        }
        
        [Test]
        [TestCase("", null,"","", false)]
        [TestCase(null, null,null," ", false)]
        [TestCase("Company", "ul. 3 Lipy 5 Gdansk", "123-456-78-90", "12345678901111111111111111", true)]
        public void CheckIfClientSellerDataIsNotNull(string company, string address, string nip, string account, bool expected)
        {
            var result = _sut.ClientSellerDataNull(company, address, nip, account);

            Assert.AreEqual(result, expected);
        }

        [Test]
        [TestCase("",null ,null , false)]
        [TestCase(null, null, null, false)]
        [TestCase("Buty", 10, 59.99, true)]
        public void CheckIfFvDataIsNotNull(string product_name, int amount, double price, bool expected)
        {
            var result = _sut.FvDataNull(product_name, amount, price);

            Assert.AreEqual(result, expected);
        }

        [Test]
        [TestCase("Melisa",10, 3 ,3.69)]
        [TestCase("T-Shirt", 50, 25, 30.75)]
        [TestCase("Buty Sportowe", 100, 30, 36.9 )]

        public void CheckIfBruttoPriceIsEqual(string name, int amount, double netto_price, double brutto_price)
        {
            var result = _sut.BruttoPrice(name, amount, netto_price);

            Assert.That(result, Is.EqualTo(brutto_price));
        }
        
        [Test]
        [TestCase("Melisa", 10, 3, 30)]
        [TestCase("T-Shirt", 50, 25, 1250)]
        [TestCase("Buty Sportowe", 100, 30, 3000)]
        [TestCase("Piłka do siatkówki", 120, 38.79, 4654.80)]

        public void CheckIfNettoXAmountIsEqual(string name, int amount, double netto_price, double netto_x_amount)
        {
            var result = _sut.NettoXAmountPrice(name, amount, netto_price);

            Assert.That(result, Is.EqualTo(netto_x_amount));
        }

        [Test]
        [TestCase("Melisa", 10, 3, 3.69)]
        [TestCase("T-Shirt", 50, 25, 34.44)]
        [TestCase("Buty Sportowe", 100, 30, 71.34)]
        [TestCase("Piłka do siatkówki", 120, 38.79, 119.05)]
        public void CheckIfBruttoFromWholeFVisEqual(string name, int amount, double netto_price, double brutto_from_wholeFV)
        {
            var result = _sut.BruttoFromWholeFV(name, amount, netto_price);

            Assert.That(result, Is.EqualTo(brutto_from_wholeFV));
        }
        // klient / Sprzedajacy
        [Test]
        [TestCase("123-456-78-90", true)]
        [TestCase("12-456-78-90", false)]
        [TestCase("dsfsdfgsdg", false)]
        [TestCase("123-456-78-90-10", false)]
        [TestCase("abc-def-gh-jk", false)]
        public void CheckIfNipIsValid(string nip, bool expected)
        {
            var result = _sut.NipCheck(nip);

            Assert.AreEqual(result, expected);
        }

        [Test]
        [TestCase("12345678901234567890111111", true)]
        [TestCase("1234567890123456789011111131231231231", false)]
        [TestCase("", false)]
        [TestCase("123", false)]
        [TestCase("asdasda", false)]
        [TestCase("1111312-==75675f///31231231", false)]
        public void CheckIfAccountNumberIsValid(string account_number, bool expected) 
        {
            var result = _sut.AccountNumberCheck(account_number);

            Assert.AreEqual(result, expected);
        }

        [Test]
        [TestCase("10.10.2010", true)]
        [TestCase("0.0.2010", false)]
        [TestCase("123", false)]
        [TestCase("abcd", false)]
        [TestCase("01202010", false)]
        [TestCase("ab.bc.2010", false)]
        public void CheckIfBuyingDateIsValid(string date, bool expected) 
        {
            var result = _sut.DateOfBuyingCheck(date);

            Assert.AreEqual(result, expected);
        }

        [Test]
        [TestCase("10.10.2010", true)]
        [TestCase("12.01.2019", true)]
        [TestCase("0.0.2010", false)]
        [TestCase("123", false)]
        [TestCase("abcd", false)]
        [TestCase("01202010", false)]
        [TestCase("ab.bc.2010", false)]
        public void CheckIfSellingDateIsValid(string date, bool expected)
        {
            var result = _sut.DateOfSellingCheck(date);

            Assert.AreEqual(result, expected);
        }

        [Test]
        [TestCase("10.10.2010", true)]
        [TestCase("0.0.2010", false)]
        [TestCase("123", false)]
        [TestCase("abcd", false)]
        [TestCase("01202010", false)]
        [TestCase("ab.bc.2010", false)]
        public void CheckIfMakingFVDateIsValid(string date, bool expected)
        {
            var result = _sut.DateOfMakingFVCheck(date);

            Assert.AreEqual(result, expected);
        }
    }

}