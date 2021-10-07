using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    [FirestoreData]
    public class DocumentosAluno
    {
        [FirestoreProperty]
        public string RegistroCivil { get; set; }
        [FirestoreProperty]
        public string DataEmissaoRegCivil { get; set; }
        [FirestoreProperty]
        public string Cpf { get; set; }
        [FirestoreProperty]
        public string Rg { get; set; }
        [FirestoreProperty]
        public string DataExpedicaoRg { get; set; }
        [FirestoreProperty]
        public string OrgaoEmissor { get; set; }
        [FirestoreProperty]
        public string UfRg { get; set; }
        [FirestoreProperty]
        public string NumCertidaoNascimento { get; set; }
        [FirestoreProperty]
        public string DataEmissaoCertNascimento { get; set; }
        [FirestoreProperty]
        public string Folha { get; set; }
        [FirestoreProperty]
        public string Livro { get; set; }
    }
}
