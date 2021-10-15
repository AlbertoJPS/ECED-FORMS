using DALProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALProject
{
   public class ControllerDeletarAluno
    {
        public static async Task<Response> DeletarAluno(DeletarAluno delete)
        {
            return await DeletarAlunoDB.DeletarAluno(delete);
        }
    }
}
