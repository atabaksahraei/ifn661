using System;
using CoreBluetooth;
using CoreFoundation;

namespace xBeacons
{
	class iOSBluetoothManager : CBPeripheralManagerDelegate
	{
		IxBluetoothState observer;
		CBPeripheralManager peripheralMgr;
		public iOSBluetoothManager (IxBluetoothState observer)
		{
			this.observer = observer;
			peripheralMgr = new CBPeripheralManager (this, DispatchQueue.DefaultGlobalQueue);
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

}

