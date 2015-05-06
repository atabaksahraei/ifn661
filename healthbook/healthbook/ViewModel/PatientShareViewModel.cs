using System;

namespace healthbook.ViewModel
{
	public class PatientShareViewModel : ViewModelHealthBase
	{
		public Patient Me { get; set; }
		public Doctor Doc { get; set; }

		public PatientShareViewModel ()
		{
			Me = new Patient () {
				Name = "Mark",
				Image = "http://www.fatosdesconhecidos.com.br/wp-content/uploads/2014/11/06162144983530.jpg"
			};

			Doc = new Doctor () {
				Name = "Dr John Corfe",
				Image = "http://completedentalguide.co.uk/wp-content/uploads/2013/12/should-I-go-to-the-dentist-or-doctors.png"
			};
		}
	}
}

