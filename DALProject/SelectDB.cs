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
                vetor.Sort();


                return new Response()
                {
                    Executed = true,
                    Message = "Cadastro com Sucesso."
                };


            }
            catch (Exception e)
            {
                return new Response()
                {
                    Executed = false,
                    Message = "Cadastro não efetuado. \n Por favor verifique suas informações."
                };
            }

        }

        public static Task<Response> MostrarDados(Aluno name, List<string> vetor)
        {
            throw new NotImplementedException();
        }
    }
}
