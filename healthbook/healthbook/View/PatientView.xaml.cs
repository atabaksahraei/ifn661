using System;
using System.Collections.Generic;

using Xamarin.Forms;
using healthbook.ViewModel;
using healthbook.Model.BL;

namespace healthbook
{
	public partial class PatientView : ContentPage
	{

		#region const
		public const string CONTEXT = "PatientView";
		#endregion

		#region var
		public PatientViewModel Vm
		{
			get
			{
				return (PatientViewModel) BindingContext;
			}
		}
		#endregion

		public PatientView ()
		{

			InitializeComponent ();
			BindingContext = new PatientViewModel (Manager.Instance.MePatient);
			if (Manager.Instance.AppMode == AppMode.Patient) {
				ToolbarItems.Add (new ToolbarItem ("share", null, async () => {
					Navigation.PushAsync (new PatientShareView ());
				}));
			}
		}

		public PatientView (Patient patient)
		{
			InitializeComponent ();
			BindingContext = new PatientViewModel (patient);
			if (Manager.Instance.AppMode == AppMode.Patient) {
				ToolbarItems.Add (new ToolbarItem ("share", null, async () => {
					Navigation.PushAsync (new PatientShareView ());
				}));
			}
		}
	}
}

