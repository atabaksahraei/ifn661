using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace healthbookService.DataObjects
{
    public class Patient : EntityData
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int BeaconMinor { get; set; }
        public string HealtDataSteps { get; set; }
        public string HealtDataSleepQuality { get; set; }
        public string HealtDataDepression { get; set; }

        public Patient()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}