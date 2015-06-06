using System;
using System.Collections.Generic;

using Xamarin.Forms;
using healthbook.ViewModel;
using healthbook.Model.BL;

namespace healthbook
{
	public partial class PatientView : ContentPage
	{

		#region const
		public const string CONTEXT = "PatientView";
		#endregion

		#region var
		public PatientViewModel Vm
		{
			get
			{
				return (PatientViewModel) BindingContext;
			}
		}
		#endregion

		public PatientView ()
		{

			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);    
			BindingContext = new PatientViewModel (Manager.Instance.MePatient);
		}

		public PatientView (Patient patient)
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);    
			BindingContext = new PatientViewModel (patient);
			DrawChart ();
		}

		void OnTapGestureRecognizerBack (object sender, EventArgs args)
		{
			Navigation.PopAsync ();

		}

		void OnTapGestureRecognizerShareDoc (object sender, EventArgs args)
		{
			Navigation.PushAsync (new PatientShareView ());
		}

		void DrawChart ()
		{
			string html = @"<html>
  <head>
    <script type=""text/javascript"" src=""https://www.google.com/jsapi""></script>
    <script type=""text/javascript"">
      google.load(""visualization"", ""0.7"", {packages:[""bar""]});
      google.setOnLoadCallback(drawChart);
      function drawChart() {
        var data = google.visualization.arrayToDataTable([
          ['', '', ''],
          ['2014', 1000, 400],
          ['2015', 1170, 460],
          ['2016', 660, 1120],
          ['2017', 1030, 540]
        ]);

        var options = {
          chart: {
          }
        };

        var chart = new google.charts.Bar(document.getElementById('columnchart_material'));

        chart.draw(data, options);
      }
    </script>
  </head>
  <body>
    <div id=""columnchart_material"" style=""width: 500px; height: 200px;""></div>
  </body>
</html>";
			ChartView.Source = new HtmlWebViewSource(){Html=html};
		}
	}
}

