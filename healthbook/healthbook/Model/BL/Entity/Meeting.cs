using System;
using System.Text;

namespace healthbook
{
	public class Meeting
	{
		public string Id { get; set; }

		public string Description { get; set; }

		public DateTime Start { get ; set; }

		public DateTime End { get; set; }

		public string FormattedStart {
			get{
				return Start.ToShortTimeString ();
			}
		}

		public string FormattedDuration {
			get {
				var diff = End.Subtract (Start);
				if (diff.TotalHours > 0) {
					return String.Format ("{0} h", diff.TotalHours);
				} else {
					return String.Format ("{0} min", diff.TotalMinutes);
				}
			}
		}

		public Meeting ()
		{
			Id = Guid.NewGuid ().ToString ();
			Start = new DateTime ();
			End = new DateTime ();

		}

	}
}

