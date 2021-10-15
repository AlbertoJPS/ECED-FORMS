using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    [FirestoreData]
    public class IdentificacaoEscolar
    {
        [FirestoreProperty]
        public string CodigoDoInep { get; set; }
        [FirestoreProperty]
        public string UnidadeEscolar { get; set; }
        [FirestoreProperty]
        public string Turno { get; set; }
        [FirestoreProperty]
        public string Turma { get; set; }
        [FirestoreProperty]
        public string Idade { get; set; }
        [FirestoreProperty]
        public string DataMatricula { get; set; }
        [FirestoreProperty]
        public string AuthBuscarCrianca { get; set; }
        [FirestoreProperty]
        public string TelefoneAutorizado { get; set; }
        [FirestoreProperty]
        public string GrauParentAuto { get; set; }
        [FirestoreProperty]
        public string PessoaAviso { get; set; }
        [FirestoreProperty]
        public string TelefoneAviso { get; set; }
        [FirestoreProperty]
        public string GrauParentAviso { get; set; }
        [FirestoreProperty]
        public string IrmaoEstuda { get; set; }
        [FirestoreProperty]
        public string TurmaIrmao { get; set; }
        [FirestoreProperty]
        public string TurnoIrmao { get; set; }
    }
}