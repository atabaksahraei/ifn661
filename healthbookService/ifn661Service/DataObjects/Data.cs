using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Healthbook.DataObjects
{
    public class PatientData : EntityData
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}