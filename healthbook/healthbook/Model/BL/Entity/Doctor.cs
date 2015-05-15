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

		public override bool Equals (Object obj)
		{
			if (obj != null) {
				bool parentIsEquals = base.Equals (obj);
				if (Id == ((Doctor)obj).Id
				   && Name == ((Doctor)obj).Name
				   && Image == ((Doctor)obj).Image
				   && BeaconMinor == ((Doctor)obj).BeaconMinor) {
					return true && parentIsEquals;
				}
			}

			return false;
		}
	}
}

