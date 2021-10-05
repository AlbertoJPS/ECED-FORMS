using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    public class SaudeAluno
    {
        public bool ProblemaSaude { get; set; }
        public string ProblemaSaudeDetalhe { get; set; }
        public bool AlergiaMedicamento{ get; set; }
        public string AlergiaMedicamentoDetalhe { get; set; }
        public bool IntoleranciaAlimento { get; set; }
        public string IntoleranciaAlimentoDetalhe { get; set; }
        public bool DietaEspecifica { get; set; }
        public string DietaEspecificaDetalhe{ get; set; }
        public bool Deficiencia{ get; set; }
        public string DeficienciaDetalhe{ get; set; }
        public string ContatoEmergUm{ get; set; }
        public string TelefoneEmergUm{ get; set; }
        public string ContatoEmergDois{ get; set; }
        public string TelefoneEmergDois{ get; set; }
        public string TelefoneContato{ get; set; }
    }
}
