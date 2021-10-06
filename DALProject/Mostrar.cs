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

                Dictionary<string, object> DadosPessoais = new Dictionary<string, object>();

                Dictionary<string, object> data1 = new Dictionary<string, object>()
                {
                    {"NOME",al.NomeAluno},
                  
                };
                DadosPessoais.Add("Dados Pessoais", data1);    

                return new Response()
                {
                    Executed = true,
                    Message = "Cadastro com Sucesso."
                };

            }
            catch (Exception)
            {
                return new Response()
                {
                    Executed = false,
                    Message = "Cadastro não efetuado. \n Por favor verifique suas informações."
                };
            }
        }

    }
}
