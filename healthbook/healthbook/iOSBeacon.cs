using System;
using Xamarin.Forms;
using CoreBluetooth;
using CoreLocation;
using CoreFoundation;
using Foundation;
using System.Collections.Generic;

namespace xBeacons
{

	class BTPeripheralDelegate : CBPeripheralManagerDelegate
	{
		IxBluetoothState observer;

		public BTPeripheralDelegate (IxBluetoothState observer)
		{
			this.observer = observer;
		}

		public override void StateUpdated (CBPeripheralManager peripheral)
		{
			switch (peripheral.State) {
			case CBPeripheralManagerState.PoweredOn:
				observer.BluetoothStateChanged (BluetoothState.PoweredOn);
				break;

			case CBPeripheralManagerState.PoweredOff:
				observer.BluetoothStateChanged (BluetoothState.PoweredOff);
				break;

			case CBPeripheralManagerState.Resetting:
				observer.BluetoothStateChanged (BluetoothState.Resetting);
				break;

			case CBPeripheralManagerState.Unauthorized:
				observer.BluetoothStateChanged (BluetoothState.Unauthorized);
				break;

			case CBPeripheralManagerState.Unknown:
				observer.BluetoothStateChanged (BluetoothState.Unknown);
				break;

			case CBPeripheralManagerState.Unsupported:
				observer.BluetoothStateChanged (BluetoothState.Unsupported);
				break;
			}

		}
	}

	public class iOSBeacon
	{
		static readonly string uuid = "E2C56DB5-DFFB-48D2-B060-D0F5A71096E0";
		static readonly string regionId = "Monkey";

		IxBeaconObserver observer;
		BTPeripheralDelegate peripheralDelegate;
		CBPeripheralManager peripheralMgr;
		CLLocationManager locationMgr;
		CLProximity previousProximity;
		CLBeaconRegion beaconRegion;
		List<xBeacon> beacons;



		public iOSBeacon (IxBeaconObserver observer)
		{
			peripheralDelegate = new BTPeripheralDelegate (observer);
			peripheralMgr = new CBPeripheralManager (peripheralDelegate, DispatchQueue.DefaultGlobalQueue);
			beacons = new List<xBeacon> ();
			this.observer = observer;
			initBeacon ();
		}

		public void initBeacon ()
		{

			//TODO: iterative
			var nsUUID = new NSUuid (uuid);
			beaconRegion = new CLBeaconRegion (nsUUID, regionId);

			beaconRegion.NotifyEntryStateOnDisplay = true;
			beaconRegion.NotifyOnEntry = true;
			beaconRegion.NotifyOnExit = true;
			//end 


			locationMgr = new CLLocationManager ();
			locationMgr.RequestWhenInUseAuthorization ();

			locationMgr.RegionEntered += (object sender, CLRegionEventArgs e) => observer.RegionEntered (e.Region.Identifier);

			locationMgr.DidRangeBeacons += (object sender, CLRegionBeaconsRangedEventArgs e) => {
				List<xBeacon> tmpList = new List<xBeacon> ();
				foreach (CLBeacon clBeacon in e.Beacons) {
					tmpList.Add (xBeacon.FromCLBeacon (clBeacon));
				}
				beacons = tmpList;
				observer.BeaconsFound (beacons);
			};

			//TODO: iterative
			locationMgr.StartMonitoring (beaconRegion);
			locationMgr.StartRangingBeacons (beaconRegion);
			//end
		}

	}
}

