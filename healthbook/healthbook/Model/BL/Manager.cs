using System;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Threading.Tasks;
using System.Collections.Generic;

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
		const string localDbPath    = "localstore.db";
		#endregion

		#region var
		private static Manager me = null;
		private MobileServiceClient client;
		private IMobileServiceSyncTable<Patient> patientTable;
		public List<Patient> Items { get; private set;}

		#endregion

		#region singleton
		public static Manager Instance {
			get {
				if(me == null)
				{
					me = new Manager();
				}
				return me;
			}
		}
		#endregion

		#region constructor
		private Manager ()
		{
			client = new MobileServiceClient(applicationURL, applicationKey);
			CurrentPlatform.Init ();
			SQLitePCL.CurrentPlatform.Init(); 

			patientTable = client.GetSyncTable <Patient> ();
			Items = new List<Patient> ();

		}
		#endregion

		#region init
		public async Task InitializeStoreAsync()
		{
			var store = new MobileServiceSQLiteStore(localDbPath);
			store.DefineTable<Patient>();

			// Uses the default conflict handler, which fails on conflict
			// To use a different conflict handler, pass a parameter to InitializeAsync. For more details, see http://go.microsoft.com/fwlink/?LinkId=521416
			await client.SyncContext.InitializeAsync(store);
		}
		#endregion

		#region synchronization
		public async Task SyncAsync()
		{
			try
			{
				await client.SyncContext.PushAsync();
				await patientTable.PullAsync("allPatientItems", patientTable.CreateQuery()); // query ID is used for incremental sync
			}

			catch (MobileServiceInvalidOperationException e)
			{
				Console.Error.WriteLine(@"Sync Failed: {0}", e.Message);
			}
		}

		public async Task<List<Patient>> RefreshDataAsync ()
		{
			try {
				// update the local store
				// all operations on todoTable use the local database, call SyncAsync to send changes
				await SyncAsync(); 							

				// This code refreshes the entries in the list view by querying the local TodoItems table.
				// The query excludes completed TodoItems
				Items = await patientTable.ToListAsync ();
				String wait= "fffff";
			} catch (MobileServiceInvalidOperationException e) {
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
				return null;
			}

			return Items;
		}
		#endregion

		#region datamanipulation
		public async Task InsertPatientItemAsync (Patient patientItem)
		{
			try {                
				await patientTable.InsertAsync (patientItem); // Insert a new TodoItem into the local database. 
				await SyncAsync(); // send changes to the mobile service

				Items.Add (patientItem); 

			} catch (MobileServiceInvalidOperationException e) {
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
			}
		}

		#endregion
	}
}

