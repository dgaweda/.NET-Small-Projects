namespace Registry
{
    interface ITrader : IWorker
    {
        public int Provision { get;  set; }
    }
}
