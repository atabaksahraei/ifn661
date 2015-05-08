using System;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace healthbook.Model.BL
{
	public interface IManager
	{

	}

	public class Manager
	{
		#region constant

		public const string APP_CONTEXT = "Manager";
		const string applicationURL = @"https://ifn661.azure-mobile.net/";
		const string gatewayURL = @"https://ifn661.azure-mobile.net/";
		const string applicationKey = @"wNGmbBuotheUnKbsLsXNpIfOrYIXyp87";
		const string localDbPath = "localstore.db";

		#endregion

		#region var

		private static Manager me = null;
		private MobileServiceClient client;
		public IMobileServiceSyncTable<Patient> PatientTable;
		private IMobileServiceSyncTable<Doctor> DocTable;

		public AppMode AppMode { get; set; }

		public List<Patient> PatientItems { get; private set; }

		public Patient MePatient { get; private set; }

		private string meName = "Mark";

		public List<Doctor> DoctorItems { get; private set; }

		public Doctor MeDoctor { get; private set; }

		#endregion

		#region singleton

		public static Manager Instance {
			get {
				if (me == null) {
					me = new Manager ();
				}
				return me;
			}
		}

		#endregion

		#region constructor

		private Manager ()
		{
			client = new MobileServiceClient (applicationURL, applicationKey);
			CurrentPlatform.Init ();

			#if __IOS__
			SQLitePCL.CurrentPlatform.Init (); 
			#endif

			PatientTable = client.GetSyncTable <Patient> ();
			DocTable = client.GetSyncTable <Doctor> ();
			PatientItems = new List<Patient> ();

		}

		#endregion

		#region init

		public async Task InitializeStoreAsync ()
		{
			var store = new MobileServiceSQLiteStore (localDbPath);
			store.DefineTable<Patient> ();
			store.DefineTable<Doctor> ();

			// Uses the default conflict handler, which fails on conflict
			// To use a different conflict handler, pass a parameter to InitializeAsync. For more details, see http://go.microsoft.com/fwlink/?LinkId=521416
			await client.SyncContext.InitializeAsync (store);
		}

		#endregion

		#region setter

		public void SetAppBaseData (string name, AppMode appMode)
		{
			meName = name;
			AppMode = appMode;
		}

		#endregion

		#region synchronization

		public async Task SyncAsync ()
		{
			try {
				await client.SyncContext.PushAsync ();
				await PatientTable.PullAsync ("allPatientItems", PatientTable.CreateQuery ()); // query ID is used for incremental sync
				await DocTable.PullAsync ("allDoctorItems", DocTable.CreateQuery ()); // query ID is used for incremental sync
			} catch (MobileServiceInvalidOperationException e) {
				Console.Error.WriteLine (@"Sync Failed: {0}", e.Message);
			}
		}

		public async Task RefreshDataAsync ()
		{
			try {
				// update the local store
				// all operations on todoTable use the local database, call SyncAsync to send changes
				await SyncAsync (); 							

				// This code refreshes the entries in the list view by querying the local TodoItems table.
				// The query excludes completed TodoItems
				PatientItems = await PatientTable.ToListAsync ();
				DoctorItems = await DocTable.ToListAsync ();

				//looking for Patient
				switch (AppMode) {
				case AppMode.Patient: 
					
					Patient tmpMePat = null;
					tmpMePat = PatientItems.First<Patient> (d => d.Name == meName);
					if (tmpMePat != null) {
						MePatient = tmpMePat;
					} 
					break;

				case AppMode.Doctor:
					Doctor tmpMeDoc = null;
					tmpMeDoc = DoctorItems.First<Doctor> (d => d.Name == meName);
					if (tmpMeDoc != null) {
						MeDoctor = tmpMeDoc;
					}
					break;
				}
				if(MeDoctor == null)
				{
					MeDoctor = DoctorItems.First<Doctor>();
				}
			} catch (MobileServiceInvalidOperationException e) {
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
			}
		}

		#endregion

		#region datamanipulation

		public async Task InsertPatientAsync (Patient patientItem)
		{
			try {                
				await PatientTable.InsertAsync (patientItem); // Insert a new TodoItem into the local database. 
				await SyncAsync (); // send changes to the mobile service

				PatientItems.Add (patientItem); 

			} catch (MobileServiceInvalidOperationException e) {
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
			}
		}

		public async Task DeletePatientAsync (Patient patientItem)
		{
			try {                
				await PatientTable.DeleteAsync (patientItem); // Insert a new TodoItem into the local database. 
				await SyncAsync (); // send changes to the mobile service
				PatientItems.RemoveAll ((x) => x.Id == patientItem.Id);

			} catch (MobileServiceInvalidOperationException e) {
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
			}
		}

		#endregion
	}
}

