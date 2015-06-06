using System;

using Xamarin.Forms;
using healthbook.ViewModel;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using healthbook.Model.BL;

namespace healthbook
{
	public partial class WelcomeView : ContentPage
	{

		#region const
		public const string CONTEXT = "WelcomeView";
		#endregion

		#region var
		public WelcomeViewModel Vm
		{
			get
			{
				return (WelcomeViewModel) BindingContext;
			}
		}
		#endregion

		public WelcomeView ()
		{
			BindingContext = new WelcomeViewModel();
			InitializeComponent ();
		}


		 void btnPatientClicked(object sender, EventArgs args) {
			var nv = new NavigationPage (new PatientView()) {Title="Healthbook"};
			nv.BarBackgroundColor = Color.FromHex("84B001");
			nv.BarTextColor = Color.White;
			App.Instance.MainPage = nv;
			Vm.SetAppData (Manager.TMP_PATIENT_NAME, AppMode.Patient);
		}

		 void btnDocClicked(object sender, EventArgs args) {
			var nv = new NavigationPage (new DoctorOverviewView()) {Title="Healthbook"};
			nv.BarBackgroundColor = Color.FromHex("84B001");
			nv.BarTextColor = Color.White;
			App.Instance.MainPage = nv;
			Vm.SetAppData (Manager.TMP_DOCTOR_NAME, AppMode.Doctor);
		}

	}
}

