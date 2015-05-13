using System;
using healthbook.Model.BL;

namespace healthbook.ViewModel
{
	public class WelcomeViewModel:ViewModelHealthBase
	{
		#region const
			public const string CONTEXT = "WelcomeViewModel";
		#endregion

		#region var

		#endregion

		public WelcomeViewModel () : base()
		{
			initial ();
		}

		async void initial()
		{
			await Manager.Instance.InitializeStoreAsync();
			await Manager.Instance.RefreshDataAsync ();

		}

		public void SetAppData(string name, AppMode mode)
		{
			Manager.Instance.SetAppBaseData (name, mode);
		}

	}
}

