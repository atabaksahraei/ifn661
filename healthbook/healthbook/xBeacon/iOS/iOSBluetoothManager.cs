using System;
using CoreBluetooth;
using CoreFoundation;
using CoreLocation;
using Foundation;

namespace xBeacons
{
	class iOSBluetoothManager : CBPeripheralManagerDelegate
	{
		IxBluetoothState observer;
		CBPeripheralManager peripheralMgr;
		CBPeripheralManagerState state ;

		public void StartVitualBeacon(xBeaconRegion region, int power)
		{

			CLBeaconRegion clRegion = region.ToCLBeaconRegion ();

			if (state == CBPeripheralManagerState.PoweredOn){
				peripheralMgr.StartAdvertising (clRegion.GetPeripheralData (power));
		} else {
				peripheralMgr.StopAdvertising ();
		}
		}

		public void StopVitualBeacon()
		{
				peripheralMgr.StopAdvertising ();
		}

		public iOSBluetoothManager (IxBluetoothState observer)
		{
			this.observer = observer;
			peripheralMgr = new CBPeripheralManager (this, DispatchQueue.DefaultGlobalQueue);
			state = CBPeripheralManagerState.Unknown;
		}

		public override void StateUpdated (CBPeripheralManager peripheral)
		{
			state = peripheral.State;

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

}

