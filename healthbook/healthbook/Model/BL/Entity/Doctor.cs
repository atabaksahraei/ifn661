using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace healthbook
{
	public class Doctor
	{
		public string Id { get; set; }
		public string PidL { get; set; }
		public string Degree { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public string PhoneNumber { get; set; }
		public string SMSNumber { get; set; }
		public string SOSNumber { get; set; }
		public string EMail { get; set; }
		public int BeaconMinor { get; set; }

		public IEnumerable<string> MyPatientIds {
			get {
				if(String.IsNullOrEmpty(PidL))
					return null;

				return JsonConvert.DeserializeObject <List<string>> (PidL);
			}
		}


		public Doctor ()
		{
			Id = Guid.NewGuid ().ToString ();
		}

		public void AddPatient(string patientId)
		{
			if(String.IsNullOrEmpty(patientId))
				return;
			List<String> patients = new List<string>(MyPatientIds);
			patients.Add(patientId);
			PidL = JsonConvert.SerializeObject (patients);
		}

		public void RemovePatient(string patientId)
		{
			if(String.IsNullOrEmpty(patientId))
				return;
			
			List<String> patients = new List<string>(MyPatientIds);
			patients.Remove(patientId);
			PidL = JsonConvert.SerializeObject (patients);
		}
		public override bool Equals (Object obj)
		{
			if (obj != null) {
				bool parentIsEquals = base.Equals (obj);
				if (Id == ((Doctor)obj).Id
				   && Name == ((Doctor)obj).Name
				   && Image == ((Doctor)obj).Image
				   && BeaconMinor == ((Doctor)obj).BeaconMinor) {
					return true && parentIsEquals;
				}
			}

			return false;
		}
	}
}

