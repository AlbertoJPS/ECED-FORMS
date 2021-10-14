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
                DocumentReference doc = DBConection.Getdatabase().Collection(al.NomeAluno).Document("Dados Pessoais");
                Dictionary<string, object> aluno = new Dictionary<string, object>
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
                Task<WriteResult> t = doc.SetAsync(aluno);
                t.Wait();

                return new Response() { Executed = true, Message = "Cadastro com Sucesso." };
            }
            catch (Grpc.Core.RpcException)
            {
                return new Response { Executed = false, Message = "Verifique sua conexão!" };
            }
            catch (Exception)
            {
                return new Response { Executed = false, Message = "Cadastro não efetuado. \n Por favor verifique suas informações." };
            }
        }
    }
}
