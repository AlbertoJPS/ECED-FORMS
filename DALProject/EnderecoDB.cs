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
                DocumentReference doc = DBConection.Getdatabase().Collection("Dados Pessoais").Document(aluno.NomeAluno);
                Dictionary<string, object> city = new Dictionary<string, object>
                {
                    {"CEP", endereco.Cep},
                    {"Rua", endereco.Rua},
                    {"Bairro", endereco.Bairro},
                    {"Cidade", endereco.Cidade},
                    {"Número", endereco.Numero},
                    {"Estado", endereco.Estado},
                    {"Avenida", endereco.Avenida},
                    {"Complemento", endereco.Complemento},
                    {"Ponto de Referencia", endereco.PontoReferencia}
                };
                Task<WriteResult> t = doc.SetAsync(city);
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
