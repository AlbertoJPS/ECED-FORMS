using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    [FirestoreData]
    public class DadosPais
    {
        [FirestoreProperty]
        public string ResponsavelUm { get; set; }
        [FirestoreProperty]
        public string NomeResponsavelUm { get; set; }
        [FirestoreProperty]
        public string DataNascimentoRespUm { get; set; }
        [FirestoreProperty]
        public string TelefoneRespUm { get; set; }
        [FirestoreProperty]
        public string CpfRespUm { get; set; }
        [FirestoreProperty]
        public string RgRespUm { get; set; }
        [FirestoreProperty]
        public string DataExpedicaoRgRespUm { get; set; }
        [FirestoreProperty]
        public string UfRgRespUm { get; set; }
        [FirestoreProperty]
        public string orgaoEmissorRgRespUm { get; set; }
        [FirestoreProperty]
        public string EstadoCivilRespUm { get; set; }
        [FirestoreProperty]
        public string EscolaridadeRespUm { get; set; }
        [FirestoreProperty]
        public string ProfissaoRespUm { get; set; }
        [FirestoreProperty]
        public string LocalTrabalhoRespUm { get; set; }
        [FirestoreProperty]
        public string HorarioTrabalhoRespUm { get; set; }
        [FirestoreProperty]
        public string RamalRespUm { get; set; }
        [FirestoreProperty]
        public string ResponsavelDois { get; set; }
        [FirestoreProperty]
        public string NomeResponsavelDois { get; set; }
        [FirestoreProperty]
        public string DataNascimentoRespDois { get; set; }
        [FirestoreProperty]
        public string TelefoneRespDois { get; set; }
        [FirestoreProperty]
        public string CpfRespDois { get; set; }
        [FirestoreProperty]
        public string RgRespDois { get; set; }
        [FirestoreProperty]
        public string DataExpedicaoRgRespDois { get; set; }
        [FirestoreProperty]
        public string UfRgRespDois { get; set; }
        [FirestoreProperty]
        public string orgaoEmissorRgRespDois { get; set; }
        [FirestoreProperty]
        public string EstadoCivilRespDois { get; set; }
        [FirestoreProperty]
        public string EscolaridadeRespDois { get; set; }
        [FirestoreProperty]
        public string ProfissaoRespDois { get; set; }
        [FirestoreProperty]
        public string LocalTrabalhoRespDois { get; set; }
        [FirestoreProperty]
        public string HorarioTrabalhoRespDois { get; set; }
        [FirestoreProperty]
        public string RamalRespDois { get; set; }
    }
}
