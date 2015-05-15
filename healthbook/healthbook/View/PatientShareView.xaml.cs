using Xamarin.Forms;
using healthbook.ViewModel;
using xBeacons;
using System;
using healthbook.Model.BL;
using System.Text;

namespace healthbook
{
	public partial class PatientShareView : ContentPage
	{

		#region const
		public const string CONTEXT = "PatientShareView";
		#endregion

		#region var
		public PatientShareViewModel Vm
		{
			get
			{
				return (PatientShareViewModel) BindingContext;
			}
		}
		iOSBeaconManager beaconManager;
		#endregion

		public PatientShareView ()
		{
			BindingContext = new PatientShareViewModel ();

			#if __IOS__
			beaconManager = new iOSBeaconManager (Vm);
			beaconManager.AddBeaconMonitoring (Manager.BEACON_REGION_UUID, Manager.BEACON_REGION_NAME);
			//beaconManager.StartVitualBeacon("E2C56DB5-DFFB-48D2-B060-D0F5A71096E0", 0, 0, "healthbook", -59);
			#endif

			InitializeComponent ();


			ToolbarItems.Add(new ToolbarItem("refresh", null, async () =>
				{
					Vm.refresh();	
				}));
		}


	}
}

