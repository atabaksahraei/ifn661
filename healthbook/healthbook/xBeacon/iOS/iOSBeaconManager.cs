using System;
using Xamarin.Forms;
using CoreLocation;
using Foundation;
using System.Collections.Generic;
using CoreBluetooth;

namespace xBeacons
{
	public class iOSBeaconManager
	{

		IxBeaconObserver observer;
		iOSBluetoothManager peripheralDelegate;
		CLLocationManager locationMgr;
		CLProximity previousProximity;
		List<CLBeaconRegion> beaconRegions;
		List<xBeacon> beacons;



		public iOSBeaconManager (IxBeaconObserver observer)
		{
			peripheralDelegate = new iOSBluetoothManager (observer);
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

		public void CreateVirtualBeacon(string UUID, int major, int minor, int power)
		{
			
		}

	}
}

