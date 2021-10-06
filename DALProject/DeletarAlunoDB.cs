using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    public class DeletarAlunoDB
    {
        public static async Task<Response> DeletarAluno(DeletarAluno delete)
        {
            try
            {

                CollectionReference coRef = DBConection.Getdatabase().Collection(delete.Nome);
            
                QuerySnapshot snap = await coRef.GetSnapshotAsync();

                foreach (DocumentSnapshot doc in snap.Documents)
                {
                    await doc.Reference.DeleteAsync();
                }

                

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

