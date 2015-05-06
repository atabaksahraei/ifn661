using System;
using System.Collections.Generic;

using Xamarin.Forms;
using healthbook.ViewModel;

namespace healthbook
{
	public partial class PatientView : ContentPage
	{
		public PatientViewModel Vm
		{
			get
			{
				return (PatientViewModel) BindingContext;
			}
		}
		public PatientView (Patient patient)
		{
			InitializeComponent ();
			BindingContext = new PatientViewModel ();
			Vm.Patient = patient;
			ToolbarItems.Add(new ToolbarItem("refresh", null, async () =>
				{

				}));
		}
	}
}

