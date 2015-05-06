using System;

namespace healthbook
{
	public class Patient
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }

		public Patient ()
		{
			Id = Guid.NewGuid ().ToString ();
		}
	}
}

