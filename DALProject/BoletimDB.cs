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

                DocumentReference doc = DBConection.Getdatabase().Collection("Dados Pessoais").Document(aluno.NomeAluno);
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
