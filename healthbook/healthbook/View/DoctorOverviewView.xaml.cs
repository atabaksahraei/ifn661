using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace healthbook
{
	public partial class DoctorOverviewView : ContentPage
	{
		public DoctorOverviewView ()
		{
			InitializeComponent ();
			ToolbarItems.Add(new ToolbarItem("refresh", null, async () =>
				{

				}));
		}
	}
}

