
using System;
using System.Collections.Generic;
using System.Text;

namespace Rynek
{
    public class Seller : Element, IObserver<Inflation>, IObservable<Accessories>
    {
        public List<IObserver<Accessories>> observers;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public Accessories accessory { get; set; }
        public double Profit { get; set; }
        public double FinalPrice { get; set; }
        public int Amount { get; set; }
        private IDisposable _unsubscriber;

        public Seller(Accessories accessory, int Amount, string FirstName, string LastName, double Profit, double FinalPrice)
        {
            this.Amount = Amount;
            this.accessory = accessory;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Profit = Profit;
            this.FinalPrice = Math.Round((accessory.Price * Profit), 2);
        }
        public Seller(IObservable<Inflation> provider)
        {
            _unsubscriber = provider.Subscribe(this);
        }
        

        public void Subscribe(IObservable<Inflation> provider)
        {
            if (_unsubscriber == null)
                _unsubscriber = provider.Subscribe(this);
        }

        public void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }

        public void OnCompleted() // powiadamia obserwatora o koncu transmisji
        {
            Console.WriteLine("End of transmission");
        }

        public void OnError(Exception e)
        {
            Console.WriteLine("Cannot get an inflation level.");
        }

        public void OnNext(Inflation value)
        {
            Console.WriteLine("\n{1} {2}: Notified that inflation level is {0}%\n", value.inflation, FirstName, LastName);
            this.FinalPrice = Math.Round(FinalPrice * (100+value.inflation)/100, 2);
            this.accessory.Price = Math.Round(accessory.Price * (100 + value.inflation) / 100, 2);
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return String.Format("Product: {0} \nAmount:{5} \nSellerName: {1} \nSellerName: {2} \nProfit: {3} \nFinalPrice: {4}\n", accessory.Name, FirstName, LastName, Profit, FinalPrice, Amount);
        }

        ///Seller Observer
        public Seller()
        {
            observers = new List<IObserver<Accessories>>();
        }

        public IDisposable Subscribe(IObserver<Accessories> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new Unsubscriber(observers, observer);
        }
    }
}
