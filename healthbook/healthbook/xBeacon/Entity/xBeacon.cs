using System;

namespace xBeacons
{
	public class xBeacon
	{
		public string UUID { get; set; }

		public int Major { get; set; }

		public int Minor { get; set; }

		public double Accuracy { get; private set; }

		public ProximityType Proximity{ get; private set; }

		public xBeacon ()
		{

		}

		public xBeacon (string UUID, int major = 0, int minor = 0, double accuracy = 0.0d, ProximityType proximity = ProximityType.Unknow)
		{
			this.UUID = UUID;
			this.Major = major;
			this.Minor = minor;
			this.Proximity = proximity;
		}

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
			return new xBeacon (beacon.ProximityUuid.AsString (), beacon.Major.Int32Value, beacon.Minor.Int32Value, beacon.Accuracy, proximity);
		}

		public override string ToString ()
		{
			return string.Format ("[xBeacon: UUID={0}, Major={1}, Minor={2}, Accuracy={3}, Proximity={4}]", UUID, Major, Minor, Accuracy, Proximity);
		}
	}
}

