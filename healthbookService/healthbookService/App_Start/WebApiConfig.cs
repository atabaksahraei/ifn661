using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using System.Linq;
using Microsoft.WindowsAzure.Mobile.Service;
using healthbookService.DataObjects;
using healthbookService.Models;
using Newtonsoft.Json;

namespace healthbookService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            Database.SetInitializer(new healthbookInitializer());
        }
    }

    public class healthbookInitializer : ClearDatabaseSchemaIfModelChanges<healthbookContext>
    {
        protected override void Seed(healthbookContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            List<Patient> patients = new List<Patient>()
            {
                new Patient() { Name = "Adam", Image = "http://www.atabak.de/ifn661/adam.jpg"},
                new Patient() { Name = "Seymour", Image = "http://www.atabak.de/ifn661/sym.jpg"},
                new Patient() { Name = "Josh", Image = "https://pbs.twimg.com/profile_images/3085413998/97782dfdce9bfeaf9e510bd991ab54c0.jpeg"},
                new Patient() { Name = "Rebekah", Image = "https://studyerpdotorg.files.wordpress.com/2012/03/pc1503452.jpg"}
           };

            foreach (Patient patient in patients)
            {
                context.Set<Patient>().Add(patient);
            }

            List<Doctor> docItems = new List<Doctor>
            {
               new Doctor(){Name="Dr. Bonny", Degree= "B. Sc.", BeaconMinor = 0, Image="http://www.atabak.de/ifn661/bonny.jpg", PhoneNumber = "+61469421579", SOSNumber = "+61469421579", SMSNumber = "+61469421579", EMail = "bonnyhbo@hotmail.com"},
               new Doctor(){Name="Dr. Dian", Degree= "M. Sc.", BeaconMinor = 1, Image="http://staff.qut.edu.au/files/avatars/398/48e931abc48c13958674c274ea285377-bpfull.jpg", PhoneNumber = "+61403226405", SOSNumber = "+61403226405", SMSNumber = "+61403226405", EMail = "atabak@sahraei.de"}
            };

            foreach (Doctor docItem in docItems)
            {
                List<string> myIds = new List<string>();
                foreach (Patient patient in patients)
                {
                    myIds.Add(patient.Id);
                }
                docItem.PidL = JsonConvert.SerializeObject(myIds);
                context.Set<Doctor>().Add(docItem);
            }
           Patient p = new Patient() { Name = "Atabak", Image = "http://www.atabak.de/ifn661/atabak.jpg" };
            context.Set<Patient>().Add(p);



            base.Seed(context);
        }
    }
}

