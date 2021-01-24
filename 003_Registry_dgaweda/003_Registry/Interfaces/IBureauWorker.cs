namespace Registry
{
    interface IBureauWorker : IWorker
    {
        public string BureauWorkerID { get; set; }
        public int IQ { get; set; }
    }
}

