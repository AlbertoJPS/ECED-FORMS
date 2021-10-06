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
        public static Response InsertEndereco(Boletim notas,Boletim aluno)
        {
            try
            {
                DocumentReference doc = DBConection.Getdatabase().Collection(aluno.NomeAluno).Document("Boletim");
                Dictionary<string, object> city = new Dictionary<string, object>
            {
                    {"Nome Aluno", notas.NomeAluno},
                    {"Materia", notas.Materia},
                    {"Turma", notas.Turma},
                    {"Nota 1", notas.Nota1},
                    {"Nota 2", notas.Nota2},
                    {"Nota 3", notas.Nota3},
            };
                doc.SetAsync(city);

                return new Response()
                {
                    Executed = true,
                    Message = "Cadastro com Sucesso."
                };

            }
            catch (Exception)
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
