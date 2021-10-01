using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    public static class Checker
    {
        /// <summary>
        /// value= string to be checked, size <=value.legngth
        /// </summary>
        /// <param name="value"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool stringChecker(string value, int size)
        {

            return (!string.IsNullOrEmpty(value) && value.Length <= size);
        }


    


}
}
