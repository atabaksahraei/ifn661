using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace healthbook
{
	public partial class TestListView : ContentPage
	{
		class aXcBindingUIList
		{
			public string ItemSource { get; set; }
			public string Text { get; set; }
			public string Detail { get; set; }
			public string Image { get; set; }

			public static string GetBindungString(string binding, string mode="TwoWay")
			{
				return String.Format (@"{0}Binding {1}, Mode={2}{3}", "{", binding, mode, "}");
			}
		}

		public TestListViewModel Vm 
		{
			get{
				return (TestListViewModel)BindingContext;
			}
		}

		public TestListView ()
		{
			//InitializeComponent ();
			BindingContext = new TestListViewModel ();

			String JSON = @"";
			
			aXcBindingUIList bUI = new aXcBindingUIList ();
			bUI.ItemSource = "Patients";
			bUI.Text = "Name";
			bUI.Detail = "Id";
			bUI.Image = "Image";
			var list = new ListView ();
			//var cell = new DataTemplate(typeof(TextCell));

//			if (!String.IsNullOrEmpty (bUI.ItemSource) && !String.IsNullOrWhiteSpace (bUI.ItemSource)) {
//				list.ItemsSource = aXcBindingUIList.GetBindungString (bUI.ItemSource);
//
//
//				if(!String.IsNullOrEmpty(bUI.Text) && !String.IsNullOrWhiteSpace(bUI.Text))
//					cell.SetBinding (TextCell.TextProperty, aXcBindingUIList.GetBindungString (bUI.Text));
////
////				if(!String.IsNullOrEmpty(bUI.Detail) && !String.IsNullOrWhiteSpace(bUI.Detail))
////					cell.SetBinding (TextCell.DetailProperty, aXcBindingUIList.GetBindungString (bUI.Detail));
////
////				if(!String.IsNullOrEmpty(bUI.Image) && !String.IsNullOrWhiteSpace(bUI.Image))
////					cell.SetBinding (ImageCell.ImageSourceProperty,aXcBindingUIList.GetBindungString (bUI.Image));
//
//				list.ItemTemplate = cell;
//
//			}

			list.ItemsSource = Vm.Patients;
			list.HasUnevenRows = true; // if using a custom template for each cell you might want to enable this.

			var cell = new DataTemplate(typeof(ImageCell));

			cell.SetBinding(TextCell.TextProperty, "Name");
			cell.SetBinding(TextCell.DetailProperty, "Id");
			cell.SetBinding(ImageCell.ImageSourceProperty, "Image");

			list.ItemTemplate = cell;


			Content = list;



		}

		public class TwoRowTemplate : ViewCell
		{
			public TwoRowTemplate()
			{
				this.Height = 25;
				var title = new Label
				{
					Font = Font.SystemFontOfSize(NamedSize.Small, FontAttributes.Bold),
					TextColor = Color.White,
					VerticalOptions = LayoutOptions.Center
				};
						
				View = new StackLayout
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					HeightRequest = 25,
					BackgroundColor = Color.FromRgb(52, 152, 218),
					Padding = 5,
					Orientation = StackOrientation.Horizontal,
					Children = { title }
				};
			}
		}
	}
}	

