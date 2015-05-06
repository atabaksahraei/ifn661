using System;
using Xamarin.Forms;
using System.Diagnostics;
using Microsoft.WindowsAzure.MobileServices;

namespace healthbook
{
	public class App : Application
	{
		private static readonly string COLOR_GREEN_HEALTH = "84B001";
		public static App Instance;
		public App ()
		{
			Instance = this;
			MainPage = new WelcomeView();
		}


		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

