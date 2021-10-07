using DALProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALProject
{
    public class ControllerBoletim
    {


        public static async Task<Response> MostrarBoletim(Boletim name, List<string> vetor)
        {
            return await SelectDB.MostrarDados(name, vetor);

        }
    }
}