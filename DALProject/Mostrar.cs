using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALProject;

namespace DALProject
{
  public  class Mostrar
    {
        public static async Task<Response> mostrarAL(Aluno al)
        {
            try
            {

                Query alunodt = DBConection.Getdatabase().Collection(al.ToString());
                QuerySnapshot snap = await alunodt.GetSnapshotAsync();



               // DocumentReference doc = DBConection.Getdatabase().Collection("Aluno").Document(al.NomeAluno);
                Dictionary<string, object> DadosPessoais = new Dictionary<string, object>();

                Dictionary<string, object> data1 = new Dictionary<string, object>()
                {
                    {"NOME",al.NomeAluno},
                    //{"Data de Nascimento",al.DataNascimento},
                    //{"Cor / Raça",al.CorERaca },
                    //{"Sexo",al.Sexo },
                    //{"Naturalidade",al.naturalidade },
                    //{"Nacionalidade",al.nacionalidade},
                    //{"Uf",al.UF },
                    //{"Estado civil",al.EstadoCivil },
                };
                DadosPessoais.Add("Dados Pessoais", data1);

                

                return new Response()
                {
                    Executed = true,
                    Message = "Deu Certo"
                };

            }
            catch (Exception)
            {
                return new Response()
                {
                    Executed = false,
                    Message = "Deu Ruim"
                };
            }
        }

    }
}
