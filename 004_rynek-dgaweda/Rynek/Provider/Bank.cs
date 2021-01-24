
using System;
using System.Collections.Generic;
using System.Text;

namespace Rynek
{
    public class Bank : IObservable<Inflation>
    {
        public List<IObserver<Inflation>> observers;

        public Bank()
        {
            observers = new List<IObserver<Inflation>>();
        }

        public IDisposable Subscribe(IObserver<Inflation> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new Unsubscriber(observers, observer);
        }

        public void SetInflation(double inflation)
        {
            foreach (var observer in observers)
                observer.OnNext(new Inflation(inflation));
        }
    }
}
