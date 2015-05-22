using Xamarin.Forms;
using healthbook.ViewModel;
using xBeacons;
using System;
using healthbook.Model.BL;
using System.Text;
using ImageCircle.Forms.Plugin.iOS;

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
			DisplayAlert("Doc Tap", "Doc Tapped", "OK");

		}


	}
}

