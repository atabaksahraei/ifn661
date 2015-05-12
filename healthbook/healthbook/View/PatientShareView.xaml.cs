using Xamarin.Forms;
using healthbook.ViewModel;
using xBeacons;
using System;

namespace healthbook
{
	public partial class PatientShareView : ContentPage, IxBeaconObserver
	{
		static readonly string uuid = "E2C56DB5-DFFB-48D2-B060-D0F5A71096E0";
		static readonly string monkeyId = "Monkey";
		public const string CONTEXT = "PatientShareView";
			
		public PatientShareViewModel Vm
		{
			get
			{
				return (PatientShareViewModel) BindingContext;
			}
		}

		public PatientShareView ()
		{
			InitializeComponent ();

			#if __IOS__
			new iOSBeacon (this).AddBeaconMonitoring ("E2C56DB5-DFFB-48D2-B060-D0F5A71096E0", "TestRegion");
			;
			#endif

			BindingContext = new PatientShareViewModel ();
			ToolbarItems.Add(new ToolbarItem("refresh", null, async () =>
				{
					Vm.refresh();	
				}));
		}

		#region IxBeaconObserver implementation
		public void BeaconsFound (System.Collections.Generic.IEnumerable<xBeacon> beacons)
		{
			foreach (xBeacon beacon in beacons) {
				Console.WriteLine (String.Format("{0}>BeaconFound: {1}",CONTEXT,  beacon.ToString ()));
			}
		}
		public void RegionEntered (string regionName)
		{
			Console.WriteLine (String.Format("{0}>RegionEntered: {1}",CONTEXT,  regionName));
		}
		public void RegionExit (string regionName)
		{
			Console.WriteLine (String.Format("{0}>RegionExit: {1}",CONTEXT,  regionName));
		}
		#endregion
		#region IxBluetoothState implementation
		public void BluetoothStateChanged (BluetoothState state)
		{
			Console.WriteLine (String.Format("{0}>BluetoothStateChanged: {1}",CONTEXT,  state.ToString()));
		}
		#endregion
	}
}

