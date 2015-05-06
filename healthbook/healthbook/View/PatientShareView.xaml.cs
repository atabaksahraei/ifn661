using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace healthbook
{
	public partial class PatientShareView : ContentPage
	{
		public PatientShareView ()
		{
			InitializeComponent ();
			ToolbarItems.Add(new ToolbarItem("refresh", null, async () =>
				{
					
				}));
		}
	}
}

