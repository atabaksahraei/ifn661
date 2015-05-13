using System;
using Xamarin.Forms;
using CoreLocation;
using Foundation;
using System.Collections.Generic;
using CoreBluetooth;
using System.Threading;
using healthbook.Model.BL;

namespace xBeacons
{
	public class iOSBeaconManager
	{
		#region const
		public const string CONTEXT = "Manager";
		#endregion

		#region var
		IxBeaconObserver observer;
		iOSBluetoothManager iosBluetoothManager;
		CLLocationManager locationMgr;
		CLProximity previousProximity;
		List<CLBeaconRegion> beaconRegions;
		List<xBeacon> beacons;
		#endregion


		public iOSBeaconManager (IxBeaconObserver observer)
		{
			iosBluetoothManager = new iOSBluetoothManager (observer);
			locationMgr = new CLLocationManager ();
			locationMgr.RequestWhenInUseAuthorization ();

			#region locationManagerEvent
			locationMgr.RegionEntered += (object sender, CLRegionEventArgs e) => observer.RegionEntered (e.Region.Identifier);

			locationMgr.DidRangeBeacons += (object sender, CLRegionBeaconsRangedEventArgs e) => {
				List<xBeacon> tmpList = new List<xBeacon> ();
				foreach (CLBeacon clBeacon in e.Beacons) {
					tmpList.Add (xBeacon.FromCLBeacon (clBeacon));
				}
				beacons = tmpList;
				observer.BeaconsFound (beacons);
			};

			locationMgr.RangingBeaconsDidFailForRegion += (object sender, CLRegionBeaconsFailedEventArgs e) => {
				TraceManager.Trace (CONTEXT, "DeletePatientAsync# Error: ", Thread.CurrentThread.ManagedThreadId, e.Error.ToString());
			};
			#endregion

			beacons = new List<xBeacon> ();
			this.observer = observer;
		}

		public void AddBeaconMonitoring (string UUID, string regionID)
		{
			var nsUUID = new NSUuid (UUID);
			CLBeaconRegion beaconRegion = new CLBeaconRegion (nsUUID, regionID);

			beaconRegion.NotifyEntryStateOnDisplay = true;
			beaconRegion.NotifyOnEntry = true;
			beaconRegion.NotifyOnExit = true;

			locationMgr.StartMonitoring (beaconRegion);
			locationMgr.StartRangingBeacons (beaconRegion);

		}

		public void StartVitualBeacon(string uuid, int major, int minor, string regionName, int power)
		{
			xBeaconRegion region = new xBeaconRegion () {
				UUID = uuid,
				Major = major,
				Minor = minor,
				RegionName = regionName
			};
			StartVitualBeacon (region, power);
		}

		public void StartVitualBeacon(xBeaconRegion region, int power)
		{
			iosBluetoothManager.StartVitualBeacon (region, power);
		}

		public void StopVitualBeacon()
		{
			iosBluetoothManager.StopVitualBeacon ();
		}


	}
}

