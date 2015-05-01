using Xamarin.Forms;
using healthbook.ViewModel;

namespace healthbook
{
	public partial class Login : ContentPage
	{
		public LoginViewModel Vm
		{
			get
			{
				return (LoginViewModel) BindingContext;
			}
		}

		public Login ()
		{
			InitializeComponent ();
			BindingContext = new LoginViewModel ();
		}

	}
}

