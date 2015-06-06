using Xamarin.Forms;
using healthbook.ViewModel;
using xBeacons;
using System;
using healthbook.Model.BL;
using System.Text;
using ImageCircle.Forms.Plugin.iOS;
using System.Collections.Generic;
using System.Linq;

namespace healthbook
{
	public partial class PatientShareView : ContentPage
	{

		#region const

		public const string CONTEXT = "PatientShareView";

		#endregion

		#region var

		public PatientShareViewModel Vm {
			get {
				return (PatientShareViewModel)BindingContext;
			}
		}

		#endregion

		public PatientShareView ()
		{
			BindingContext = new PatientShareViewModel ();

			InitializeComponent ();
			ImageCircleRenderer.Init ();

			ToolbarItems.Add (new ToolbarItem ("refresh", null, async () => {
				Vm.refresh ();	
			}));
			
		}

		void OnTapGestureRecognizerTappedDoc (object sender, EventArgs args)
		{
			DocClickHelper ();

		}

		async void DocClickHelper()
		{
			if (Vm.Doc != null) {
				List<String> docPatientList = new List<string>(Vm.Doc.MyPatientIds);
				string tmpPatient = docPatientList.Where (item => item == Vm.Me.Id).FirstOrDefault();
				if (String.IsNullOrEmpty (tmpPatient)) {
					Vm.Doc.AddPatient (Vm.Me.Id);
					DisplayAlert ("Sharing", "Shared", "OK");
				} else {

					var action = await DisplayActionSheet ("ActionSheet: Send to?", "Cancel", null,  "remove Sharing", "Call", "SOS Call", "Message");

					switch (action) {
					case "Call": 
						#if __IOS__
						var call = Foundation.NSUrl.FromString(String.Format("tel:{0}", Vm.Doc.PhoneNumber));
						UIKit.UIApplication.SharedApplication.OpenUrl(call);
						#endif
						break;
					case "remove Sharing": 
						Vm.Doc.RemovePatient (Vm.Me.Id);
						Vm.SyncToCloud ();
						DisplayAlert ("Sharing remove", "Sharing removed", "OK");
						break;
					case "SOS Call": 
						#if __IOS__
						var sosCall = Foundation.NSUrl.FromString(String.Format("tel:{0}", Vm.Doc.SOSNumber));
						UIKit.UIApplication.SharedApplication.OpenUrl(sosCall);
						#endif
						break;
					case "Message": 
						#if __IOS__
						var messageTo = Foundation.NSUrl.FromString(String.Format("sms:{0}", Vm.Doc.SMSNumber));
						UIKit.UIApplication.SharedApplication.OpenUrl(messageTo);
						#endif
						break;
					}

				}
			}
		}


	}
}

