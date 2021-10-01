using DALProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALProject
{
  public  class Controller
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
    }
}
