using System;
using xBeacons;
using System.Collections.Generic;
using System.Linq;
using healthbook.Model.BL;
using System.Threading;

namespace healthbook.ViewModel
{
	public class PatientShareViewModel : ViewModelHealthBase, IxBeaconObserver
	{
		#region const

		public const string CONTEXT = "PatientShareViewModel";

		#endregion

		#region var

		public Patient Me { get; set; }

		public int DocOpc { get; set; }

		public Doctor Doc { get; set; }

		#endregion


		public PatientShareViewModel ()
		{
			refresh ();
		}

		public async void refresh ()
		{
			await Manager.Instance.RefreshDataAsync ();
			Me = Manager.Instance.MePatient;
			Doc = new Doctor ();
			RaisePropertyChanged ("Me");
			RaisePropertyChanged ("Doc");
		}

		#region IxBeaconObserver implementation

		public void BeaconsFound (System.Collections.Generic.IEnumerable<xBeacon> beacons)
		{
			Doctor tmpDoc = null;
			foreach (xBeacon beacon in beacons) {
				TraceManager.Trace (CONTEXT, "BeaconsFound", Thread.CurrentThread.ManagedThreadId, beacon.ToString ());
			}
			
			List<Doctor> docs = Manager.Instance.DoctorItems;

			if (docs != null) {
				List<int> intersectedIds = docs.Select (x => x.BeaconMinor).Intersect (beacons.Select (x => x.Region.Minor)).ToList ();
				List<Doctor> intersectedDocs = new List<Doctor> ();
				foreach (int id in intersectedIds) {
					xBeacon beacon = beacons.Where (x => x.Region.Minor == id).First ();
					if (beacon.Proximity == ProximityType.Immediate || beacon.Proximity == ProximityType.Near) {
						intersectedDocs.Add (docs.Where (x => x.BeaconMinor == id).First ());
					}
				}
				if (intersectedDocs.Count > 0) {
					Doc = intersectedDocs.First ();
				} else {
					Doc = new Doctor ();
				}
			} else {
				Doc = new Doctor ();
			}
		
			//if (!Doc.Equals (tmpDoc)) {
				RaisePropertyChanged ("Doc");
			//}
		}

		public void RegionEntered (string regionName)
		{
			TraceManager.Trace (CONTEXT, "RegionEntered", Thread.CurrentThread.ManagedThreadId, regionName);
		}

		public void RegionExit (string regionName)
		{
			TraceManager.Trace (CONTEXT, "RegionExit", Thread.CurrentThread.ManagedThreadId, regionName);
		}

		#endregion

		#region IxBluetoothState implementation

		public void BluetoothStateChanged (BluetoothState state)
		{
			TraceManager.Trace (CONTEXT, "BluetoothStateChanged", Thread.CurrentThread.ManagedThreadId, state.ToString ());
		}

		#endregion
	}
}

