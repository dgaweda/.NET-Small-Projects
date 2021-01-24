
using System;
using System.Collections.Generic;
using System.Text;

namespace Rynek
{
    public class Buyer : IObserver<Inflation>, IObserver<Accessories>
    {
        Sellers seller = new Sellers();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Inflation inflation { get; set; }
        private IDisposable _unsubscriber;
        private IDisposable _unsubscriberSeller;
        public string Need { get; set; }
        public double Money { get; set; }
        public Buyer(string FirstName, string LastName, string Need, double Money)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Need = Need;
            this.Money = Money;
        }
        public Buyer(IObservable<Inflation> provider, IObservable<Accessories> seller)
        {
            _unsubscriber = provider.Subscribe(this);
            _unsubscriberSeller = seller.Subscribe(this);
        }

        public void Subscribe(IObservable<Inflation> provider, IObservable<Accessories> seller)
        {
            if (_unsubscriber == null)
            {
                _unsubscriber = provider.Subscribe(this);
            }
            
            if (_unsubscriberSeller == null)
            {
                _unsubscriberSeller = seller.Subscribe(this);
            }
        }

        public void Unsubscribe()
        {
            _unsubscriber.Dispose();
            _unsubscriberSeller.Dispose();
        }

        public void OnCompleted() // powiadamia obserwatora o koncu transmisji
        {
            Console.WriteLine("End of transmission");
        }

        public void OnError(Exception e)
        {
            Console.WriteLine("Error");
        }

        public void OnNext(Inflation value)
        {
            Console.WriteLine("\n{1} {2}: Notified that inflation level is {0}%\n", value.inflation, FirstName, LastName);
        }

        public void OnNext(Accessories field)
        {
            if (field.Name.Equals(Need))
            {
                this.Money = Money - field.Price;
                Console.WriteLine("{0} notified that there's an opportunity to buy specified accessory: {1}", FirstName, field.Name);
            }
        }

        public override string ToString() => String.Format("FirstName: {0} \nLastName: {1} \nNeed: {2} \n",FirstName, LastName, Need);
    }
}
