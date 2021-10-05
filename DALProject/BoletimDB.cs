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
        public static Response InsertEndereco(Boletim notas, string aluno)
        {
            try
            {
                DocumentReference doc = DBConection.Getdatabase().Collection("Boletim").Document(aluno).Collection("Matéria").Document(notas.Materia);
                Dictionary<string, object> Boletim = new Dictionary<string, object>();
                Dictionary<string, object> notasBoletim = new Dictionary<string, object>()
                {
                    {"Nome Aluno", notas.NomeAluno},
                    {"Materia", notas.Materia},
                    {"Turma", notas.Turma},
                    {"Nota 1", notas.Nota1},
                    {"Nota 2", notas.Nota2},
                    {"Nota 3", notas.Nota3},
                };
                Boletim.Add(notas.Materia, notasBoletim);
                Task<WriteResult> t = doc.SetAsync(Boletim);
                t.Wait();
                return new Response()
                {
                    Executed = true,
                    Message = "Nota adicionada!"
                };
            }
            catch (Exception)
            {
                return new Response()
                {
                    Executed = false,
                    Message = "Erro"
                };
            }
        }
    }
}
