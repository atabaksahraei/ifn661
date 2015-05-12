using System;
using System.Collections.Generic;

namespace xBeacons
{
	public interface IxBeaconObserver : IxBluetoothState
	{
		void BeaconsFound (IEnumerable<xBeacon> beacons);
		void RegionEntered (string regionName);
		void RegionExit (string regionName);
	}
}

