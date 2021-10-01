using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace DALProject
{
    public class DBConection
    {
        public static Response Insert()
        {
            FirestoreDb database;


            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", AppDomain.CurrentDomain.BaseDirectory + @"eced-e3031-firebase-adminsdk-fxr0o-786505f761.json");

            database = FirestoreDb.Create("eced-e3031");

        }
    }
}
