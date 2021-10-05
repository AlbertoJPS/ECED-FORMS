using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    public static class AlunoDB
    {
        public static Response Insert(Aluno al)
        {
            try
            {

                DocumentReference doc = DBConection.Getdatabase().Collection("Dados Pessoais").Document(al.NomeAluno);
                Dictionary<string, object> city = new Dictionary<string, object>
            {
                    {"NOME",al.NomeAluno},
                    {"Data de Nascimento",al.DataNascimento},
                    {"Cor / Raça",al.CorERaca },
                    {"Sexo",al.Sexo },
                    {"Naturalidade",al.naturalidade },
                    {"nacionalidade",al.nacionalidade},
                    {"Uf",al.UF },
                    {"Estado civil",al.EstadoCivil },
            };
               
                Task<WriteResult> t = doc.SetAsync(city);
                t.Wait();

                //DocumentReference doc = DBConection.Getdatabase().Collection("Aluno").Document(al.NomeAluno);
                //Dictionary<string, object> DadosPessoais = new Dictionary<string, object>();

                //Dictionary<string, object> data1 = new Dictionary<string, object>()
                //{

                //};
                //DadosPessoais.Add("Dados Pessoais", data1);

                //Task<WriteResult> t = doc.SetAsync(DadosPessoais);
                //t.Wait();

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
