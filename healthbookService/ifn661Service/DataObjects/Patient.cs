using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Mobile.Service;

namespace ifn661Service.DataObjects
{
    public class Patient : EntityData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public Patient()
        {
            Id = Guid.NewGuid().ToString();
        }

       
    }
}
