using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace healthbook
{
	public class App : Application
	{
		private static readonly string COLOR_GREEN_HEALTH = "84B001";

		public App ()
		{

//			Button loginButton = new Button {
//				Text = "Start",
//				TextColor = Color.FromHex ("FFFFFF"),
//				BackgroundColor = Color.FromHex (COLOR_GREEN_HEALTH)
//			};
//
//			loginButton.Clicked += async (sender, e) => {
//				
//			};
//
//			Image logo = new Image {
//				Source = "Icon-76"
//			};
	
			

			var nv = new NavigationPage (new Welcome()) {Title="Healthbook"};
			nv.BarBackgroundColor = Color.FromHex("84B001");
			nv.BarTextColor = Color.White;
			MainPage = nv;

		
			// The root page of your application
		/*	MainPage = new ContentPage {
				
				BackgroundColor = Color.FromHex(COLOR_GREEN_HEALTH),
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					BackgroundColor = Color.FromHex(COLOR_GREEN_HEALTH),
					Children = {
						logo,
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Healthbook",
							TextColor = Color.White
						},
						loginButton
					}
				}
			};*/


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

