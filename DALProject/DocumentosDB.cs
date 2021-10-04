using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    public static class DocumentosDB
    {
        public static Response InsertDocumentos(DocumentosAluno docAluno, Aluno aluno)
        {
            try
            {
                DocumentReference doc = DBConection.Getdatabase().Collection("Aluno").Document(aluno.NomeAluno); //Nome do aluno para adicionar no mesmo documento que as outras informações
                Dictionary<string, object> Documentos = new Dictionary<string, object>(); //Nova coleção
                Dictionary<string, object> infoAluno = new Dictionary<string, object>()
                {
                    {"CPF",docAluno.Cpf},
                    {"RG",docAluno.Rg},
                    {"Data de Expedição(RG)",docAluno.DataExpedicaoRg},
                    {"Orgão Emissor",docAluno.OrgaoEmissor},
                    {"UF(RG)",docAluno.UfRg},
                    {"Número Certidão de Nascimento",docAluno.NumCertidaoNascimento},
                    {"Data de Emissão Certidão de Nascimento",docAluno.DataEmissaoCertNascimento},
                    {"Folha",docAluno.Folha},
                    {"Livro",docAluno.Livro},
                    {"Registro Civil",docAluno.RegistroCivil},
                    {"Data de Emissão Registro Civil",docAluno.DataEmissaoRegCivil},
                };
                Documentos.Add("Documentos", infoAluno);

                Task<WriteResult> t = doc.UpdateAsync(Documentos);
                t.Wait();

                

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
