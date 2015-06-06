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
		public bool DataLoaded { get; set; }
		public bool Loading { get; set; }
		#endregion

		public WelcomeViewModel () : base()
		{
			initial ();
		}

		async void initial()
		{
			DataLoaded = false;
			Loading = true;
			RaisePropertyChanged ("Loading");
			RaisePropertyChanged ("DataLoaded");
			await Manager.Instance.InitializeStoreAsync();
			await Manager.Instance.RefreshDataAsync ();
			DataLoaded = true;
			Loading = false;
			RaisePropertyChanged ("Loading");
			RaisePropertyChanged ("DataLoaded");

		}

		public void SetAppData(string name, AppMode mode)
		{
			Manager.Instance.SetAppBaseData (name, mode);
		}

	}
}

