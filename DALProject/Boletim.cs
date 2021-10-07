using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    [FirestoreData]
    public class Boletim
    {
        [FirestoreProperty]
        public string NomeAluno { get; set; }
        [FirestoreProperty]
        public string Turma { get; set; }
        [FirestoreProperty]
        public string Materia { get; set; }
        [FirestoreProperty]
        public double Nota1 { get; set; }
        [FirestoreProperty]
        public double Nota2 { get; set; }
        [FirestoreProperty]
        public double Nota3 { get; set; }
    }
}
