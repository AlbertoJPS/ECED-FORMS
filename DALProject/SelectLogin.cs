using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    public class SelectLogin
    {
        public static async Task<Response> ConfereLogin(Login log, bool con )
        {
            try
            {
                DocumentReference docref = DBConection.Getdatabase().Collection(log.UserName).Document(log.Senha);

                con = false;
                DocumentSnapshot snap = await docref.GetSnapshotAsync();
                if (snap.Exists)
                {
                    con = true;
                    
                }
                


                return new Response()
                {
                    Executed = true,
                    Message = "Cadastro com Sucesso."
                };


            }
            catch (Exception )
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
