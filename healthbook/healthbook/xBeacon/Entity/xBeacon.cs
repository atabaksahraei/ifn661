using System;

namespace xBeacons
{
	public class xBeacon
	{

		public xBeaconRegion Region { get; private set; }

		public double Accuracy { get; private set; }

		public ProximityType Proximity{ get; private set; }

		#region constructor
		public xBeacon()
		{
			Region = new xBeaconRegion ();
		}

		public xBeacon (string UUID, int major = 0, int minor = 0, double accuracy = 0.0d, ProximityType proximity = ProximityType.Unknow, string regionName = ""):this()
		{
			this.Region.UUID = UUID;
			this.Region.Major = major;
			this.Region.Minor = minor;
			this.Region.RegionName = regionName;
			this.Accuracy = accuracy;
			this.Proximity = proximity;
		}

		public xBeacon (xBeaconRegion region, double accuracy = 0.0d, ProximityType proximity = ProximityType.Unknow):this()
		{
			this.Region = region;
			this.Accuracy = accuracy;
			this.Proximity = proximity;
		}
		#endregion

		#region DTO
		public static xBeacon FromCLBeacon (CoreLocation.CLBeacon beacon)
		{
			ProximityType proximity = ProximityType.Unknow;
			switch (beacon.Proximity) {

			case CoreLocation.CLProximity.Immediate:
				proximity = ProximityType.Immediate;
				break;
			
			case CoreLocation.CLProximity.Near:
				proximity = ProximityType.Near;					
				break;
			
			case CoreLocation.CLProximity.Far:
				proximity = ProximityType.Far;
				break;
			}
			xBeaconRegion region = new xBeaconRegion () {
				UUID = beacon.ProximityUuid.AsString (),
				Major = beacon.Major.Int32Value,
				Minor = beacon.Minor.Int32Value
			};
			return new xBeacon (region, beacon.Accuracy, proximity);
		}
			
		#endregion

		public override string ToString ()
		{
			return string.Format ("[xBeacon: Region={0}, Accuracy={1}, Proximity={2}]", Region, Accuracy, Proximity);
		}
	}
}

