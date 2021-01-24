using System;
using System.Collections.Generic;
using System.Text;

namespace Rynek
{
    public class Unsubscriber : IDisposable
    {
        private List<IObserver<Inflation>> _observers;
        private IObserver<Inflation> _observer;

        private List<IObserver<Accessories>> _accObservers;
        private IObserver<Accessories> _accObserver;

        public Unsubscriber(List<IObserver<Inflation>> observers, IObserver<Inflation> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public Unsubscriber(List<IObserver<Accessories>> accObservers, IObserver<Accessories> accObserver)
        {
            this._accObservers = accObservers;
            this._accObserver = accObserver;
        }

        public void Dispose()
        {
            if (this._observer != null) _observers.Remove(this._observer);
            if (this._accObserver != null) _accObservers.Remove(this._accObserver);
        }
    }
}
