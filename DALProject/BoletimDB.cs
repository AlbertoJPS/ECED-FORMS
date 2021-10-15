using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    public static class BoletimDB
    {
        public static Response InsertBoletim(Boletim notas)
        {
            try
            {
                DocumentReference doc = DBConection.Getdatabase().Collection(notas.NomeAluno).Document("Boletim");
                Dictionary<string, object> infoBoletim = new Dictionary<string, object>
            {
                    {"Nome Aluno", notas.NomeAluno},
                    {"Materia", notas.Materia},
                    {"Turma", notas.Turma},
                    {"Nota 1", notas.Nota1},
                    {"Nota 2", notas.Nota2},
                    {"Nota 3", notas.Nota3},
            };
                Task<WriteResult> t = doc.SetAsync(infoBoletim);
                t.Wait();                
                return new Response()
                {
                    Executed = true,
                    Message = "Notas adicionadas!"
                };
            }
            catch (Exception)
            {
                return new Response()
                {
                    Executed = false,
                    Message = "Erro ao adicionar as notas. \n Por favor verifique as informações."
                };
            }
        }
    }
}
