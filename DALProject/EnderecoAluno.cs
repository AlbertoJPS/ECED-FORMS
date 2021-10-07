using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    [FirestoreData]
    public class EnderecoAluno
    {
        [FirestoreProperty]
        public string Cep { get; set; }
        [FirestoreProperty]
        public string Rua { get; set; }
        [FirestoreProperty]
        public string Bairro { get; set; }
        [FirestoreProperty]
        public string Cidade { get; set; }
        [FirestoreProperty]
        public string Numero { get; set; }
        [FirestoreProperty]
        public string Estado { get; set; }
        [FirestoreProperty]
        public string Avenida { get; set; }
        [FirestoreProperty]
        public string Complemento { get; set; }
        [FirestoreProperty]
        public string PontoReferencia { get; set; }
    }
}
