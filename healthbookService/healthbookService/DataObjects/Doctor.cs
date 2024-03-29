﻿using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace healthbookService.DataObjects
{
    public class Doctor : EntityData
    {
        public string Name { get; set; }
        public string Degree { get; set; }
        public string Image { get; set; }
        public int BeaconMinor { get; set; }
        public string PidL { get; set; }
        public string PhoneNumber { get; set; }
        public string SMSNumber { get; set; }
        public string SOSNumber { get; set; }
        public string EMail { get; set; }


        public Doctor()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}