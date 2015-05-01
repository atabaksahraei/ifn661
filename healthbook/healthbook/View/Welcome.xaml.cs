using System;
using System.Collections.Generic;

using Xamarin.Forms;
using healthbook.ViewModel;

namespace healthbook
{
	public partial class Welcome : ContentPage
	{
		public WelcomeViewModel Vm
		{
			get
			{
				return (WelcomeViewModel) BindingContext;
			}
		}

		public Welcome ()
		{
			BindingContext = new WelcomeViewModel();
			InitializeComponent ();
		}

		void btnStartClicked(object sender, EventArgs args) {
			 Navigation.PushAsync (new Login ());
		}

	}
}

