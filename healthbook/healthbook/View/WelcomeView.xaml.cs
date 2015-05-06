using System;

using Xamarin.Forms;
using healthbook.ViewModel;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;

namespace healthbook
{
	public partial class WelcomeView : ContentPage
	{
		
		private IMobileServiceSyncTable<Item> todoTable;

		public class Item
		{
			public string Id { get; set; }
			public string Text { get; set; }
		}

		public WelcomeViewModel Vm
		{
			get
			{
				return (WelcomeViewModel) BindingContext;
			}
		}

		public WelcomeView ()
		{

			BindingContext = new WelcomeViewModel();
			InitializeComponent ();
		}

		async void btnPatientClicked(object sender, EventArgs args) {
			var nv = new NavigationPage (new PatientShareView()) {Title="Healthbook"};
			nv.BarBackgroundColor = Color.FromHex("84B001");
			nv.BarTextColor = Color.White;
			App.Instance.MainPage = nv;
		}

		async void btnDocClicked(object sender, EventArgs args) {
			var nv = new NavigationPage (new DoctorOverviewView()) {Title="Healthbook"};
			nv.BarBackgroundColor = Color.FromHex("84B001");
			nv.BarTextColor = Color.White;
			App.Instance.MainPage = nv;
		}

	}
}

