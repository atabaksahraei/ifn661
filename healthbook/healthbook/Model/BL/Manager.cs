using System;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace healthbook.Model.BL
{
	public class Manager
	{
		#region constant
		public const string BEACON_REGION_UUID = "8AA52754-E353-40F1-A4F4-5606E15101D1";
		public const string BEACON_REGION_NAME = "healthbook";
		public const int BEACON_MAJOR_DOCTOR = 1;
		public const string CONTEXT = "Manager";
		public const bool TRACE = true;
		public const string TMP_PATIENT_NAME = "Billy";
		public const string TMP_DOCTOR_NAME = "Dr. Bonny";
		#endregion

		#region var
		const string applicationURL = @"https://healthbook.azure-mobile.net/";
		const string gatewayURL = @"https://healthbook.azure-mobile.net/";
		const string applicationKey = @"uucsuQgYwrpeGWybtMCtvAkbVDSsrd32";
//		const string applicationURL = @"https://healthbooktmp.azure-mobile.net/";
//		const string gatewayURL = @"https://healthbooktmp.azure-mobile.net/";
//		const string applicationKey = @"JrdcREVLmUjRWdlWqInKHmoyJktztE36";
		const string localDbPath = "localstore.db";

		private static Manager me = null;
		private MobileServiceClient client;
		public IMobileServiceSyncTable<Patient> PatientTable;
		private IMobileServiceSyncTable<Doctor> DocTable;

		public AppMode AppMode { get; set; }

		public List<Patient> PatientItems { get; private set; }

		public Patient MePatient {
			get{
				return PatientItems.FirstOrDefault<Patient> (d => d.Name == meName);
			} 
		}
			

		private string meName = TMP_PATIENT_NAME;

		public List<Doctor> DoctorItems { get; private set; }

		public Doctor MeDoctor { 
			get{ 
				return DoctorItems.FirstOrDefault<Doctor> (d => d.Name == meName);
			} 
		}

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
				TraceManager.Trace (CONTEXT, "SyncAsync# Faild: ", Thread.CurrentThread.ManagedThreadId, e.Message);
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


			} catch (Exception e) {
				TraceManager.Trace (CONTEXT, "RefreshDataAsync# Error: ", Thread.CurrentThread.ManagedThreadId, e.Message);
			}
		}

		#endregion

		#region datamanipulation

		public async Task UpdateAsync (Doctor doctorItem)
		{
			try {                
				await DocTable.UpdateAsync (doctorItem); // Insert a new TodoItem into the local database. 
				await SyncAsync (); // send changes to the mobile service
				DoctorItems = await DocTable.ToListAsync ();


			} catch (MobileServiceInvalidOperationException e) {
				TraceManager.Trace (CONTEXT, "InsertPatientAsync# Error: ", Thread.CurrentThread.ManagedThreadId, e.Message);
			}
		}

		public async Task InsertPatientAsync (Patient patientItem)
		{
			try {                
				await PatientTable.InsertAsync (patientItem); // Insert a new TodoItem into the local database. 
				await SyncAsync (); // send changes to the mobile service

				PatientItems.Add (patientItem); 

			} catch (MobileServiceInvalidOperationException e) {
				TraceManager.Trace (CONTEXT, "InsertPatientAsync# Error: ", Thread.CurrentThread.ManagedThreadId, e.Message);
			}
		}

		public async Task DeletePatientAsync (Patient patientItem)
		{
			try {                
				await PatientTable.DeleteAsync (patientItem); // Insert a new TodoItem into the local database. 
				await SyncAsync (); // send changes to the mobile service
				PatientItems.RemoveAll ((x) => x.Id == patientItem.Id);

			} catch (MobileServiceInvalidOperationException e) {
				TraceManager.Trace (CONTEXT, "DeletePatientAsync# Error: ", Thread.CurrentThread.ManagedThreadId, e.Message);
			}
		}

		#endregion
	}
}

