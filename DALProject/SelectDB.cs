using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    public class SelectDB
    {
        public static async Task<Response> MostrarDados(Boletim name,List<string> vetor)
        {
            try
            {
                DocumentReference docref = DBConection.Getdatabase().Collection(name.NomeAluno).Document("Boletim");

                DocumentSnapshot snap = await docref.GetSnapshotAsync();
                if (snap.Exists)
                {
                    Dictionary<string, object> dados = snap.ToDictionary();
                    foreach (var item in dados)
                    {
                        vetor.Add(item.Value.ToString());
                       
                    }
                }
                else
                {
                    return new Response { Executed = false, Message = "Aluno não encontrado. \n Por favor verifique suas informações." };
                }
                vetor.Sort();
                return new Response
                {
                    Executed = true,
                    Message = "Aluno encontrado com Sucesso."
                };
            }
            catch (Exception)
            {
                return new Response{Executed = false, Message = "Erro ao buscar aluno. \n Por favor verifique suas informações."};
            }

        }

        public static Task<Response> MostrarDados(Aluno name, List<string> vetor)
        {
            throw new NotImplementedException();
        }
    }
}
