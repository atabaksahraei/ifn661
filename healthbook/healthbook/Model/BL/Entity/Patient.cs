using System;
using System.Linq;
using System.Collections.Generic;

namespace healthbook
{
	public class Patient
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public int BeaconMinor { get; set; }
		public string HealtDataSteps { get; set; }
		public string HealtDataSleepQuality { get; set; }
		public string HealtDataDepression { get; set; }

//		public List<Meeting> Meetings { get; set; }
//		public string NextMeeting {
//			get{
//				if (Meetings != null) {
//					var tmpList = Meetings.Where (i => i.End > DateTime.Now).OrderByDescending (x => x.Start).ToList ();
//					var tmpNextMeeting = tmpList.First ();
//					if (tmpNextMeeting != null) {
//						return tmpNextMeeting.FormattedStart;
//					}
//				}
//				return string.Empty;
//			}
//		}

		public Patient ()
		{
			Id = Guid.NewGuid ().ToString ();
//			Meetings = new List<Meeting> ();
		}

//		public void GenerateRandomMeetings()
//		{
//			
//			for (int i = 0; i < 5; i++) {
//				var randomMeeting = new Meeting ();
//				DateTime start = DateTime.Now;
//				Random gen = new Random ();
//
//				int range = (DateTime.Today - start).Days;           
//				randomMeeting.Start = start.AddDays (gen.Next (range));
//				randomMeeting.End = randomMeeting.Start.AddMinutes (30.0);
//				Meetings.Add (randomMeeting);
//			}
//		}
	}
}

