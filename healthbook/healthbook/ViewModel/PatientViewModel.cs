using System;

namespace healthbook.ViewModel
{
	public class PatientViewModel : ViewModelHealthBase
	{
		#region const
		public const string CONTEXT = "PatientViewModel";
		#endregion

		#region var
		public Patient Patient { get; set; }
		#endregion

		public PatientViewModel (Patient patient)
		{
			Patient = patient;
		}
	}
}

