using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace healthbook
{
	public partial class PatientView : ContentPage
	{
		public PatientView ()
		{
			InitializeComponent ();
			ToolbarItems.Add(new ToolbarItem("refresh", null, async () =>
				{

				}));
		}
	}
}

