using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    [FirestoreData]
    public class Aluno
    {
        [FirestoreProperty]
        public int idAluno { get; set; }
        [FirestoreProperty]
        public string NomeAluno { get; set; }
        [FirestoreProperty]
        public string Sexo { get; set; }
        [FirestoreProperty]
        public string NomeMae { get; set; }
        [FirestoreProperty]
        public string NomePai { get; set; }
        [FirestoreProperty]
        public string Responsavel { get; set; }
        [FirestoreProperty]
        public int TelefoneMae { get; set; }
        [FirestoreProperty]
        public string CorERaca { get; set; }
        [FirestoreProperty]
        public string DataNascimento { get; set; }
        [FirestoreProperty]
        public string EstadoCivil { get; set; }
        [FirestoreProperty]
        public string nacionalidade{ get; set; }
        [FirestoreProperty]
        public string naturalidade{ get; set; }
        [FirestoreProperty]
        public string UF{ get; set; }
        [FirestoreProperty]
        public string Tipo{ get; set; }
    }
}
