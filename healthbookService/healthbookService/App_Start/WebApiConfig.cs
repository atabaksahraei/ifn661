﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using System.Linq;
using Microsoft.WindowsAzure.Mobile.Service;
using healthbookService.DataObjects;
using healthbookService.Models;

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
                new Patient() { Name = "Mark", Image = "http://www.fatosdesconhecidos.com.br/wp-content/uploads/2014/11/06162144983530.jpg"},
                new Patient() { Name = "Billy", Image = "https://financialpostcom.files.wordpress.com/2012/12/1212gates.jpg"},
                new Patient() { Name = "Joker", Image = "http://vignette2.wikia.nocookie.net/batman/images/4/49/MyCard_The_Joker.jpg"},
                new Patient() { Name = "Joker 2", Image = "http://vignette2.wikia.nocookie.net/batman/images/4/49/MyCard_The_Joker.jpg"},
                new Patient() { Name = "Sheldon", Image = "http://img1.wikia.nocookie.net/__cb20110725161640/bigbangtheory/de/images/5/52/Sheldons_Superblick.jpg"}
           };

            foreach (Patient patient in patients)
            {
                context.Set<Patient>().Add(patient);
            }

            List<Doctor> docItems = new List<Doctor>
            {
               new Doctor(){Name="Dr. Bonny", Degree= "B. Sc.", BeaconMinor = 0, Image="https://pbs.twimg.com/profile_images/3402491976/ebdcb1f3f9278fd540b2b6d2191e46b7_400x400.jpeg"},
               new Doctor(){Name="Dr. Dian", Degree= "M. Sc.", BeaconMinor = 1, Image="http://staff.qut.edu.au/files/avatars/398/48e931abc48c13958674c274ea285377-bpfull.jpg"}
            };

            foreach (Doctor docItem in docItems)
            {
                docItem.PidL = String.Format("[\"{0}\"]", patients.FirstOrDefault<Patient>().Id);
                context.Set<Doctor>().Add(docItem);
            }



            base.Seed(context);
        }
    }
}
