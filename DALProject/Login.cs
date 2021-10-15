using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    [FirestoreData]
    public class Login
    {
        [FirestoreProperty]
        public string UserName { get; set; }
        [FirestoreProperty]
        public string Senha { get; set; }
    }
}
