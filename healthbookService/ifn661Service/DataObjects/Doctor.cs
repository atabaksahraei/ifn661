using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ifn661Service.DataObjects
{

    public class Doctor : EntityData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Doctor()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}