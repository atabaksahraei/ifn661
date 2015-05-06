using System;

namespace healthbook.ViewModel
{
	public class PatientViewModel : ViewModelHealthBase
	{
		public Patient Patient { get; set; }
		public PatientViewModel (Patient patient)
		{
			Patient = patient;
		}
	}
}

