using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;
using healthbook.ViewModel;

namespace healthbook
{
	public partial class DoctorOverviewView : ContentPage
	{
		#region viewModel
		public DoctorOverviewViewModel Vm { 
			get { 
				return (DoctorOverviewViewModel) BindingContext;
			}
		}
		#endregion
	
		#region constructor
		public DoctorOverviewView () : base ()
		{
			//Initialization
			InitializeComponent ();
			BindingContext = new DoctorOverviewViewModel ();

			//Toolbar
			ToolbarItems.Add(new ToolbarItem("refresh", null, async () =>
				{

				}));
		}
		#endregion

		#region listEvents
		public void OnItemSelected (object sender, SelectedItemChangedEventArgs e) {
			if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event
			DisplayAlert("Tapped", e.SelectedItem + " row was tapped", "OK");
			((ListView)sender).SelectedItem = null; // de-select the row
		}


		public void OnMore (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
		}

		public void OnDelete (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);

			Debug.WriteLine ("delete " + mi.CommandParameter.ToString ());
			//Vm.CoastCatItems.RemoveAll (x => x.Name == ((CostCatItem) mi.CommandParameter).Name);
			DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
			//items.Remove (mi.CommandParameter.ToString());
		}
		#endregion
	}
}

