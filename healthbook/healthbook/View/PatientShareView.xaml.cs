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
			if (Vm.Doc != null) {
				List<String> docPatientList = new List<string>(Vm.Doc.MyPatientIds);
				string tmpPatient = docPatientList.Where (item => item == Vm.Me.Id).FirstOrDefault();
				if (String.IsNullOrEmpty (tmpPatient)) {
					Vm.Doc.AddPatient (Vm.Me.Id);
					DisplayAlert ("Sharing", "Shared", "OK");
				} else {
					Vm.Doc.RemovePatient (Vm.Me.Id);
					DisplayAlert ("Sharing", "Sharing removed", "OK");
				}
				 Vm.SyncToCloud ();
			}

		}


	}
}

