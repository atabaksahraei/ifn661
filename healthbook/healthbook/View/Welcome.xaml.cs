using System;
using System.Collections.Generic;

using Xamarin.Forms;

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
	}
}

