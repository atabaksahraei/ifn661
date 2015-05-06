using System;

using Xamarin.Forms;
using healthbook.ViewModel;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

namespace healthbook
{
	public partial class Welcome : ContentPage
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

		public Welcome ()
		{

			BindingContext = new WelcomeViewModel();
			InitializeComponent ();
		}

		async void btnStartClicked(object sender, EventArgs args) {
			
			// Navigation.PushAsync (new Login ());
		}

	}
}

