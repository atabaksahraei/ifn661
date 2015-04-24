using System;
using RestSharp;

namespace healthbook.Model.SAL
{
	public interface IWebServices {
		RestClient GetRestClient();
	}
	
	public class WebServices : IWebServices
	{
		#region constant
		public static readonly String APP_CONTEXT = "WebServices";
		#endregion

		public WebServices ()
		{
		}

		#region IWebServices implementation

		public RestClient GetRestClient ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

