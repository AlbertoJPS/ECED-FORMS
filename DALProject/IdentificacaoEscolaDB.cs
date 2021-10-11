using DALProject;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
     public static class IdentificacaoEscolaDB
    {
        public static Response InsertIdentEscola(IdentificacaoEscolar identEscola, Aluno aluno)
        {
            try
            {
                DocumentReference doc = DBConection.Getdatabase().Collection(aluno.NomeAluno).Document("Identificação escolar");
                Dictionary<string, object> identeficacao = new Dictionary<string, object>
                {
                    {"Unidade Escolar", identEscola.UnidadeEscolar},
                    {"Código do Inep", identEscola.CodigoDoInep},
                    {"Turno", identEscola.Turno},
                    {"Turma", identEscola.Turma},
                    {"Data da Matrícula", identEscola.DataMatricula},
                    {"Autorizado Buscar Criança", identEscola.AuthBuscarCrianca},
                    {"Telefone Autorizado", identEscola.TelefoneAutorizado},
                    {"Grau Parentesco", identEscola.GrauParentAuto},
                    {"Idade", identEscola.Idade},
                    {"Telefone Urgência", identEscola.TelefoneAviso},
                    {"Grau Parentesco Urgência", identEscola.GrauParentAviso},
                    {"Pessoa Urgência", identEscola.PessoaAviso},
                };         
                Task<WriteResult> t = doc.SetAsync(identeficacao);
                t.Wait();

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
