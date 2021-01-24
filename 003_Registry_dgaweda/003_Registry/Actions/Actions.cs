using System.Collections.Generic;
using System.Linq;

namespace Registry
{
    public class Actions
    {
        List<Worker> _workers = new List<Worker>();
        public List<Worker> AddWorker(Worker worker)
        {
            _workers.Add(worker);
            return _workers;
        }

        public void RemoveWorker(string ID)
        {
            var SelectedWorker = _workers.Find(field => field.ID.Contains(ID));
            _workers.Remove(SelectedWorker);
        }

        public List<Worker> ShowByCity(string City)
        {
            return _workers.Where(field => field.address.City.Equals(City)).ToList();
        }

        public int CheckValue(Worker worker)
        {
            return worker.CorpoValue();
        }

        public List<Worker> ShowWorkers()
        {
            return _workers;
        }

    }
}
