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
			Patients.Add (new Patient (){ Name = "Mark", Image = "http://www.fatosdesconhecidos.com.br/wp-content/uploads/2014/11/06162144983530.jpg" });
			Patients.Add (new Patient (){ Name = "Billy", Image = "https://financialpostcom.files.wordpress.com/2012/12/1212gates.jpg" });
			Patients.Add (new Patient (){ Name = "Joker", Image = "http://vignette2.wikia.nocookie.net/batman/images/4/49/MyCard_The_Joker.jpg" });
			Patients.Add (new Patient (){ Name = "Sheldon", Image="http://img1.wikia.nocookie.net/__cb20110725161640/bigbangtheory/de/images/5/52/Sheldons_Superblick.jpg" });
		}
	}
}

