using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;
using healthbook.Model.BL;
using xBeacons;

namespace healthbook.ViewModel
{

	public class DoctorOverviewViewModel : ViewModelHealthBase, IxBeaconObserver
	{

		#region const
		public const string CONTEXT = "DoctorOverviewViewModel";
		#endregion

		#region var

		public List<Patient> Patients { get; private set; }
		iOSBeaconManager beaconManager;

		#endregion



		public DoctorOverviewViewModel ()
		{
			Patients = new List<Patient> ();
			#if __IOS__
			beaconManager = new iOSBeaconManager (this);
			//beaconManager.AddBeaconMonitoring (Manager.BEACON_REGION_UUID, Manager.BEACON_REGION_NAME);
			beaconManager.StartVitualBeacon(Manager.BEACON_REGION_UUID, Manager.BEACON_MAJOR_DOCTOR, 0, Manager.BEACON_REGION_NAME, -59);
			#endif

		}


		public async void Delete(Patient p)
		{
			await Manager.Instance.DeletePatientAsync (p);
			Patients = Manager.Instance.PatientItems;
			RaisePropertyChanged ("Patients");

		}


		public async void refreshData()
		{
			beaconManager.StopVitualBeacon();
			beaconManager.StartVitualBeacon(Manager.BEACON_REGION_UUID, Manager.BEACON_MAJOR_DOCTOR, 0, Manager.BEACON_REGION_NAME, -59);
			await Manager.Instance.RefreshDataAsync ();
			Patients = Manager.Instance.PatientItems;
			RaisePropertyChanged ("Patients");
		}

		#region IxBeaconObserver implementation

		public void BeaconsFound (IEnumerable<xBeacon> beacons)
		{
			//throw new NotImplementedException ();
		}

		public void RegionEntered (string regionName)
		{
			//throw new NotImplementedException ();
		}

		public void RegionExit (string regionName)
		{
			//throw new NotImplementedException ();
		}

		#endregion

		#region IxBluetoothState implementation

		public void BluetoothStateChanged (BluetoothState state)
		{
			//throw new NotImplementedException ();
		}

		#endregion
	}
}

