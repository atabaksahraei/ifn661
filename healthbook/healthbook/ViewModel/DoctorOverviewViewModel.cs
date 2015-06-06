using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;
using healthbook.Model.BL;
using xBeacons;
using System.Collections.Specialized;

namespace healthbook.ViewModel
{

	public class DoctorOverviewViewModel : ViewModelHealthBase, IxBeaconObserver
	{

		#region const
		public const string CONTEXT = "DoctorOverviewViewModel";
		#endregion

		#region var
		public ObservableCollection<Patient> Patients { get; private set; }

		iOSBeaconManager beaconManager;

		#endregion

		public DoctorOverviewViewModel ()
		{
			Patients = new ObservableCollection<Patient> ();
			Patients.CollectionChanged += OnCollectionChanged;

			#if __IOS__
			beaconManager = new iOSBeaconManager (this);
			//beaconManager.AddBeaconMonitoring (Manager.BEACON_REGION_UUID, Manager.BEACON_REGION_NAME);
			beaconManager.StartVitualBeacon(Manager.BEACON_REGION_UUID, Manager.BEACON_MAJOR_DOCTOR, 0, Manager.BEACON_REGION_NAME, -59);
			#endif

		}

		private void OnCollectionChanged (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
			switch (e.Action) {
			case NotifyCollectionChangedAction.Remove:
//				Manager.Instance.DeletePatientAsync (e.OldItems);
				break;
			default:
				break;
			}

		}

		public async void Delete(Patient p)
		{
			await Manager.Instance.DeletePatientAsync (p);
			Patients = new ObservableCollection<Patient> (Manager.Instance.PatientItems);
			RaisePropertyChanged ("Patients");

		}


		public async void refreshData()
		{
			beaconManager.StopVitualBeacon();
			beaconManager.StartVitualBeacon(Manager.BEACON_REGION_UUID, Manager.BEACON_MAJOR_DOCTOR, 0, Manager.BEACON_REGION_NAME, -59);
			await Manager.Instance.RefreshDataAsync ();
			if (Manager.Instance.MeDoctor != null && Manager.Instance.MeDoctor.PidL != null) {
				Patients = new ObservableCollection<Patient> ();
				foreach (string patientId in Manager.Instance.MeDoctor.MyPatientIds) {
					Patient patient = Manager.Instance.PatientItems.Where (item => item.Id == patientId).FirstOrDefault<Patient> ();
					if (patient != null) {
						Patients.Add (patient);
					}
				}
			} else {
				Patients = new ObservableCollection<Patient> ();
			}
			
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

