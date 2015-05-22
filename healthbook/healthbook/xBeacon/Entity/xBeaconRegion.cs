using System;

namespace xBeacons
{
	public class xBeaconRegion
	{
		public string UUID { get; set; }

		public string RegionName { get; set; }

		public int Major { get; set; }

		public int Minor { get; set; }

		public xBeaconRegion ()
		{
		}

		#region DTO
		public CoreLocation.CLBeaconRegion ToCLBeaconRegion ()
		{
			Foundation.NSUuid uuid = new Foundation.NSUuid (UUID);
			Foundation.NSNumber major = new Foundation.NSNumber(Major);
			Foundation.NSNumber minor = new Foundation.NSNumber(Minor);

			if (uuid == null)
				return null;
			if (minor == null) {
				if (major == null)
					return new CoreLocation.CLBeaconRegion (uuid, RegionName);
				else
					return new CoreLocation.CLBeaconRegion (uuid, major.UInt16Value, RegionName);
			} else if (major != null) {
				return new CoreLocation.CLBeaconRegion (uuid, major.UInt16Value, minor.UInt16Value, RegionName);
			}
			return null;
		}
		#endregion

		public override string ToString ()
		{
			return string.Format ("[xBeaconRegion: UUID={0}, RegionName={1}, Major={2}, Minor={3}]", UUID, RegionName, Major, Minor);
		}
	}
}

