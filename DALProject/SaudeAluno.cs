using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    [FirestoreData]
    public class SaudeAluno
    {
        [FirestoreProperty]
        public bool ProblemaSaude { get; set; }
        [FirestoreProperty]
        public string ProblemaSaudeDetalhe { get; set; }
        [FirestoreProperty]
        public bool AlergiaMedicamento { get; set; }
        [FirestoreProperty]
        public string AlergiaMedicamentoDetalhe { get; set; }
        [FirestoreProperty]
        public bool IntoleranciaAlimento { get; set; }
        [FirestoreProperty]
        public string IntoleranciaAlimentoDetalhe { get; set; }
        [FirestoreProperty]
        public bool DietaEspecifica { get; set; }
        [FirestoreProperty]
        public string DietaEspecificaDetalhe { get; set; }
        [FirestoreProperty]
        public bool Deficiencia { get; set; }
        [FirestoreProperty]
        public string DeficienciaDetalhe { get; set; }
        [FirestoreProperty]
        public string ContatoEmergUm { get; set; }
        [FirestoreProperty]
        public string TelefoneEmergUm { get; set; }
        [FirestoreProperty]
        public string ContatoEmergDois { get; set; }
        [FirestoreProperty]
        public string TelefoneEmergDois { get; set; }
        [FirestoreProperty]
        public string TelefoneContato { get; set; }
    }
}
