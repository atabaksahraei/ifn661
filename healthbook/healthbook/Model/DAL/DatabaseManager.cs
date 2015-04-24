using System;
using System.Collections;
using System.Collections.Generic;
using SQLite;
using System.IO;


namespace healthbook.Model.DAL
{
	public interface IDatabaseObserver
	{
		void NotifyDatabaseTableChanged ();
	}

	public interface IDatabaseManager
	{
		int DropTable<T> ();

		IList<T> Query<T> (String query, ObserveFlag observeFlag = ObserveFlag.Off, IDatabaseObserver observer = null, params object[] args) where T : new();

		int CreateTable<T> (CreateFlags createFlags = CreateFlags.None);

		TableQuery<T> Table<T> (IDatabaseObserver observer = null) where T : new();

		void Save (IEnumerable data, ObserveFlag observeFlag = ObserveFlag.Off);

		void Save (Object item, ObserveFlag observeFlag = ObserveFlag.On);

		int Delete (Object item, ObserveFlag observeFlag = ObserveFlag.On);

		int[] Delete (System.Collections.IEnumerable data, ObserveFlag observeFlag = ObserveFlag.On);

	}

	public enum ObserveFlag
	{
		Off,
		On
	}

	public class DatabaseManager : IDatabaseManager
	{
		
		#region constant
		public static readonly String APP_CONTEXT = "DatabaseManager";
		#endregion

		#region var

		SQLiteConnection connection = null;
		Type observedType = null;
		IDatabaseObserver observed = null;
		TimeSpan lockTimeOut;

		#endregion

		private DatabaseManager (SQLiteConnection con, int timeOutForLockInMilliSecond)
		{
			connection = con;
			lockTimeOut = TimeSpan.FromMilliseconds (timeOutForLockInMilliSecond);
		}

		#region baseMethod

		public static DatabaseManager Create (String pathToDatabase, int timeOutForLockInMilliSecond = 15000)
		{
			#if __IOS__
				throw new NotImplementedException ();
			#endif

			#if __ANDROID__
			if (!String.IsNullOrEmpty (pathToDatabase)) {
				SQLiteConnection con;
				bool exist = File.Exists (pathToDatabase);
				if (!exist) {
					//Create a sqlite file if not exist
					File.Create (pathToDatabase);
				} 

				con = new SQLiteConnection (pathToDatabase);

				if (con != null) {
					return new DatabaseManager (con, timeOutForLockInMilliSecond);
				}
			}
			#endif

			return null;

		}

		private void MessagingObserver (Type currentType, ObserveFlag observeFlag = ObserveFlag.On)
		{
			if (observedType == currentType && observeFlag == ObserveFlag.On && observed != null) {
				observed.NotifyDatabaseTableChanged ();
			}
		}

		#endregion

		#region IDatabase_Manager implementation

		public int DropTable<T> ()
		{
			throw new NotImplementedException ();
		}

		public IList<T> Query<T> (string query, ObserveFlag observeFlag = ObserveFlag.Off, IDatabaseObserver observer = null, params object[] args) where T : new()
		{
			throw new NotImplementedException ();
		}

		public int CreateTable<T> (CreateFlags createFlags = CreateFlags.None)
		{
			throw new NotImplementedException ();
		}

		public TableQuery<T> Table<T> (IDatabaseObserver observer = null) where T : new()
		{
			throw new NotImplementedException ();
		}

		public void Save (IEnumerable data, ObserveFlag observeFlag = ObserveFlag.Off)
		{
			throw new NotImplementedException ();
		}

		public void Save (object item, ObserveFlag observeFlag = ObserveFlag.On)
		{
			throw new NotImplementedException ();
		}

		public int Delete (object item, ObserveFlag observeFlag = ObserveFlag.On)
		{
			throw new NotImplementedException ();
		}

		public int[] Delete (IEnumerable data, ObserveFlag observeFlag = ObserveFlag.On)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

