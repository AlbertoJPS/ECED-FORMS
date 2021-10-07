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
        public static async Task<Response> MostrarDados(Aluno name)
        {
            try
            {
                DocumentReference docref = DBConection.Getdatabase().Collection(name.NomeAluno).Document("Dados Pessoais");

                DocumentSnapshot snap = await docref.GetSnapshotAsync();
                if (snap.Exists)
                {
                    Dictionary<string, object> city = snap.ToDictionary();

                }
                return new Response()
                {
                    Executed = true,
                    Message = "Cadastro com Sucesso."
                };


            }
            catch (Exception)
            {

                throw;
            }

        }

        public static Task MostrarDados()
        {
            throw new NotImplementedException();
        }
    }
}
