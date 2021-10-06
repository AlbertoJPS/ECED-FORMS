using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    [FirestoreData]
    public  class DeletarAluno
    {
        [FirestoreProperty]
        public string Nome { get; set; }
    }
}
