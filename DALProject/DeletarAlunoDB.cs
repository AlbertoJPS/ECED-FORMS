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
                return new Response()
                {
                    Executed = true,
                    Message = "Aluno deletado com Sucesso."
                };
            }
            catch (Exception)
            {
                return new Response()
                {
                    Executed = false,
                    Message = "Cadastro não de deletado. \n Por favor verifique suas informações."
                };
            }
        }
    }
}

