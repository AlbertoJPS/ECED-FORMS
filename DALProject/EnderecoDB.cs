using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    public static class EnderecoDB
    {
        public static Response InsertEndereco(EnderecoAluno endereco, Aluno aluno)
        {
            try
            {
                DocumentReference doc = DBConection.Getdatabase().Collection("Aluno").Document(aluno.NomeAluno);
                Dictionary<string, object> Endereco = new Dictionary<string, object>();
                Dictionary<string, object> enderecoAluno = new Dictionary<string, object>()
                {
                    {"CEP", endereco.Cep},
                    {"Rua", endereco.Rua},
                    {"Bairro", endereco.Bairro},
                    {"Cidade", endereco.Cidade},
                    {"Número", endereco.Numero},
                    {"Estado", endereco.Estado}
                };
                Endereco.Add("Endereço", enderecoAluno);
                doc.UpdateAsync(Endereco);
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
