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
			ToolbarItems.Add(new ToolbarItem("share", null, async () =>
				{

				}));
		}

		public PatientView (Patient patient)
		{
			InitializeComponent ();
			BindingContext = new PatientViewModel (patient);
			ToolbarItems.Add(new ToolbarItem("share", null, async () =>
				{

				}));
		}
	}
}

