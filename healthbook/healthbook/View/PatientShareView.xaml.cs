using Xamarin.Forms;
using healthbook.ViewModel;

namespace healthbook
{
	public partial class PatientShareView : ContentPage
	{
		public PatientShareViewModel Vm
		{
			get
			{
				return (PatientShareViewModel) BindingContext;
			}
		}

		public PatientShareView ()
		{
			InitializeComponent ();
			BindingContext = new PatientShareViewModel ();
			ToolbarItems.Add(new ToolbarItem("refresh", null, async () =>
				{
					
				}));
		}
	}
}

