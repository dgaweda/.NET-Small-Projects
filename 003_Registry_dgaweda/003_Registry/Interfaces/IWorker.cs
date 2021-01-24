namespace Registry
{
	interface IWorker
	{
		// Name etc.

		public string Name { get; set; }

		public string LastName { get; set; }

		public int Age { get; set; }

		public int Experience { get; set; }

		public abstract int CorpoValue();
	}
}
