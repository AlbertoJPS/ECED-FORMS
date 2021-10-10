using DALProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALProject
{
    public class ControllerLogin
    {
        public static async Task<Response> confLogin(Login lo, bool conf)
        {
            return await SelectLogin.ConfereLogin(lo, conf);

        }
    }
}
