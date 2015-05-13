using System;
using System.Linq;
using System.Collections.Generic;

namespace healthbook
{
	public class Doctor
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public int BeaconMinor { get; set; }


		public Doctor ()
		{
			Id = Guid.NewGuid ().ToString ();
		}
	}
}

