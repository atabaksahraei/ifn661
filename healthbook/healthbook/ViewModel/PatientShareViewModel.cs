using System;
using healthbook.Model.BL;

namespace healthbook.ViewModel
{
	public class PatientShareViewModel : ViewModelHealthBase
	{
		public Patient Me { get; set; }
		public Doctor Doc { get; set; }

		public PatientShareViewModel ()
		{
			refresh ();
		}
		public async void refresh()
		{
			await Manager.Instance.RefreshDataAsync();
			Me = Manager.Instance.MePatient;
			Doc = Manager.Instance.MeDoctor;
			RaisePropertyChanged ("Me");
			RaisePropertyChanged ("Doc");
		}
	}
}

