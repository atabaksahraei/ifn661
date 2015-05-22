using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;

namespace Healthbook.Controllers
{
    public class SharingController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/Sharing
        public string Get()
        {
            Services.Log.Info("Hello from custom controller!");
            return "Hello";
        }

        public string Share(string guidDoctor)
        {
            return String.Format("Share with {0}", guidDoctor);
        }

    }
}
