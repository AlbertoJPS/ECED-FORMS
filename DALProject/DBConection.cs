using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace DALProject
{
    public static class DBConection
    {
        private static FirestoreDb database;
        /// <summary>
        /// return an instance of the DataBese Connection
        /// </summary>
        /// <returns></returns>
        public static FirestoreDb Getdatabase()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", AppDomain.CurrentDomain.BaseDirectory + @"eced-e3031-firebase-adminsdk-fxr0o-786505f761.json");

            database = FirestoreDb.Create("eced-e3031");
            return database;
        }
    }
}


