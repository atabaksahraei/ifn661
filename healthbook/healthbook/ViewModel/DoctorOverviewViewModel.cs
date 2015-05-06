﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;
using healthbook.Model.BL;

namespace healthbook.ViewModel
{

	public class DoctorOverviewViewModel : ViewModelHealthBase
	{
		public List<Patient> Patients { get; private set; }

		public DoctorOverviewViewModel ()
		{
			Patients = new List<Patient> ();
			initData ();

		}

		 async void initData ()
		{
			await Manager.Instance.InitializeStoreAsync ();
			refreshData ();
		}

		public async void Delete(Patient p)
		{
			await Manager.Instance.DeletePatientAsync (p);
			Patients = Manager.Instance.Items;
			RaisePropertyChanged ("Patients");

		}

		public async void refreshData()
		{
			await Manager.Instance.RefreshDataAsync ();
			Patients = Manager.Instance.Items;
			RaisePropertyChanged ("Patients");
		}
	}
}

