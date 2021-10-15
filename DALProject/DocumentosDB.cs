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
                DocumentReference doc = DBConection.Getdatabase().Collection(aluno.NomeAluno).Document("Documento");
                Dictionary<string, object> documen = new Dictionary<string, object>
                {
                    {"CPF",docAluno.Cpf},
                    {"RG",docAluno.Rg},
                    {"Data de Expedição(RG)",docAluno.DataExpedicaoRg},
                    {"Orgão Emissor",docAluno.OrgaoEmissor},
                    {"UF(RG)",docAluno.UfRg},
                    {"Num Certidão de Nascimento",docAluno.NumCertidaoNascimento},
                    {"Data Emissão",docAluno.DataEmissaoCertNascimento},
                    {"Folha",docAluno.Folha},
                    {"Livro",docAluno.Livro},
                    {"Registro Civil",docAluno.RegistroCivil},
                    {"Data de Emissão",docAluno.DataEmissaoRegCivil},
                };
                doc.SetAsync(documen);
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
