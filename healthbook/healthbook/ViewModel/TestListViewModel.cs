
namespace healthbook
{
	public class TestListViewModel : GalaSoft.MvvmLight.ViewModelBase
	{
		public System.Collections.ObjectModel.ObservableCollection<Patient> Patients { get; set; }
		public TestListViewModel ()
		{
			Patients = new System.Collections.ObjectModel.ObservableCollection<Patient>(){
				new Patient(){ Name = "Patient1", Image = "portrait.jpg" },
				new Patient(){ Name = "Patient2", Image = "portrait.jpg" },
				new Patient(){ Name = "Patient3", Image = "portrait.jpg" },
				new Patient(){ Name = "Patient4", Image = "portrait.jpg" },
				new Patient(){ Name = "Patient5", Image = "portrait.jpg" }
			};

		}
	}
}

