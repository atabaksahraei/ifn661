using System;
using System.Collections.Generic;

namespace healthbook.ViewModel
{
	public class DoctorOverviewViewModel : ViewModelHealthBase
	{
		public List<Patient> Patients { get; private set;}
		public DoctorOverviewViewModel ()
		{
			Patients = new List<Patient> ();
			Patients.Add (new Patient (){ Name = "Atabak" });
			Patients.Add (new Patient (){ Name = "Jens" });
			Patients.Add (new Patient (){ Name = "Jérome" });
			Patients.Add (new Patient (){ Name = "Bonny" });
		}
	}
}

