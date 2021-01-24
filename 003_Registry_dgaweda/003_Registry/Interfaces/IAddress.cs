namespace Registry
{
    interface IAddress
    {
        public string StreetName { get; set; }
        public int Building { get; set; }
        public int Local { get; set; }
        public string City { get; set; }
    }
}
