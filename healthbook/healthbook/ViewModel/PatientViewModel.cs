using System;
using healthbook.Model.BL;

namespace healthbook.ViewModel
{
	public class PatientViewModel : ViewModelHealthBase
	{
		#region const
		public const string CONTEXT = "PatientViewModel";
		#endregion

		#region var
		public Patient Patient { get; set; }
		public bool IsPatient{
			get{
				if (Manager.Instance.AppMode == AppMode.Patient)
					return true;
				return false;
			}
		}

		public bool IsDoctor{
			get{
				if (Manager.Instance.AppMode == AppMode.Doctor)
					return true;
				return false;
			}
		}

		#endregion

		public PatientViewModel (Patient patient)
		{
			Patient = patient;
		}
	}
}

