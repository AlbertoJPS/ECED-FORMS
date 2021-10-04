using DALProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BALProject
{
    public class Controller
    {
        public static Response AlunoInsert(Aluno al)
        {
            // conferencias

            // DAL

            return AlunoDB.Insert(al);
        }

        public static Response DocumentoInsert(DocumentosAluno docAluno, Aluno aluno)
        {
            return DocumentosDB.InsertDocumentos(docAluno, aluno);
        }

        public static Response EnderecoInsert(EnderecoAluno endereco, Aluno aluno)
        {
            return EnderecoDB.InsertEndereco(endereco, aluno);
        }
        public static Response IdentificacaoEscolaInsert(IdentificacaoEscolar identEscola, Aluno aluno)
        {
            return IdentificacaoEscolaDB.InsertIdentEscola(identEscola, aluno);
        }

        //public static Response Mostrartudo(Aluno all)
        //{
        //    return Mostrar.mostrarAL(all);



        //}
    }
}
