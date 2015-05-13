using System;

namespace healthbook.Model.BL
{
	public class TraceManager
	{

		#region const
		public const string CONTEXT = "TraceManager";
		#endregion

		public TraceManager ()
		{
			
		}

		public static void Trace (string context, int threadID, string message)
		{
			if (Manager.TRACE) {
				Console.WriteLine (string.Format ("{0} - {1} : {2} > {3}", DateTime.Now.ToLongTimeString() , context, threadID, message));
			}
		}


		public static void Trace (string context, string method, int threadID, string message)
		{
			Trace(String.Format("{0} > {1}", context, method), threadID, message);
		}
	}
}