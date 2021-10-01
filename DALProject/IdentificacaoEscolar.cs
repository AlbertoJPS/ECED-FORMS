using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    public class IdentificacaoEscolar
    {
        public string CodigoDoInep { get; set; }
        public string UnidadeEscolar { get; set; }
        public string Turno { get; set; }
        public string Numero { get; set; }
        public string Turma { get; set; }
        public bool Deficiencia { get; set; }
        public bool BenefBolsaFamilia { get; set; }
        public bool CartaoVacina { get; set; }
        public string DataMatricula { get; set; }
    }
}
