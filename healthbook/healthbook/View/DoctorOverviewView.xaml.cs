using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;
using healthbook.ViewModel;
using xBeacons;
using healthbook.Model.BL;

namespace healthbook
{
	public partial class DoctorOverviewView : ContentPage
	{

		#region const
		public const string CONTEXT = "DoctorOverView";
		#endregion

		#region var
		public DoctorOverviewViewModel Vm { 
			get { 
				return (DoctorOverviewViewModel) BindingContext;
			}
		}
		iOSBeaconManager beaconManager;

		#endregion
	
		#region constructor
		public DoctorOverviewView () : base ()
		{
			//Initialization

			BindingContext = new DoctorOverviewViewModel ();

			#if __IOS__
			beaconManager = new iOSBeaconManager (Vm);
			//beaconManager.AddBeaconMonitoring (Manager.BEACON_REGION_UUID, Manager.BEACON_REGION_NAME);
			beaconManager.StartVitualBeacon(Manager.BEACON_REGION_UUID, Manager.BEACON_MAJOR_DOCTOR, 1, Manager.BEACON_REGION_NAME, -59);
			#endif

			InitializeComponent ();
			//Toolbar
			ToolbarItems.Add(new ToolbarItem("refresh", null, async () =>
				{
					 Vm.refreshData();
				}));
		}
		#endregion

		#region listEvents
		public void OnRefresh(object sender, EventArgs e) {
			listOfPatients.IsRefreshing = true;
			Vm.refreshData();
			listOfPatients.IsRefreshing = false;
		}

		public async void OnItemSelected (object sender, SelectedItemChangedEventArgs e) {
			if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event

			Patient selectedPatient = ((Patient)((ListView)sender).SelectedItem);
			Navigation.PushAsync (new PatientView (selectedPatient));
			//DisplayAlert("Tapped", selectedPatient.Name + " was tapped", "OK");

			((ListView)sender).SelectedItem = null; // de-select the row
		}


		public void OnMore (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
		}

		public void OnDelete (object sender, EventArgs e) {
			var currentPatient = (Patient)(((MenuItem)sender).CommandParameter);

			Vm.Delete(currentPatient);
			Debug.WriteLine (String.Format("delete {0}", currentPatient.Name));
			DisplayAlert("Delete Patient", String.Format ("Patient {0} deleted!", currentPatient.Name), "OK");
		}
		#endregion
	}
}

