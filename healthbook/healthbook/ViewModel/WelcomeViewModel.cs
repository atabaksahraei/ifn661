using System;

namespace healthbook.ViewModel
{
	public class WelcomeViewModel:ViewModelHealthBase
	{
		private  string _test;
		public WelcomeViewModel () : base()
		{
//			_test = string.Empty;
			_test = "Welcome to Helthbook!";
		}
		public string Qut{
			get{
				return "QUT";
			}
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
				Set (() => Test, ref _test, value);
			}
		}
	}
}

