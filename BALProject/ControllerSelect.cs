
using DALProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALProject
{
    public class ControllerSelect
    {
        public static async Task<Response> MostrarDados(Aluno name)
        {
            return await SelectDB.MostrarDados(name);
        }
    }
}
