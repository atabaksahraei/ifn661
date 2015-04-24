using GalaSoft.MvvmLight;

namespace healthbook
{
	public class WelcomeViewModel : ViewModelBase
	{
		private string _test;
		public WelcomeViewModel ()
		{
			_test = null;
		}

		public string Test
		{
			get{
				return _test;
			}
			set{
				if (_test != null && _test == value) {
					return;
				}
				if (Set (() => Test, ref _test, value)) {
					RaisePropertyChanged (() => Test);
				}
			}
		}
	}
}

