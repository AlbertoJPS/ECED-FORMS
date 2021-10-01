using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    public class ControllerFunc
    {
        public static int VerificaInputs(string assunto, string nota)
        {
            if (!String.IsNullOrEmpty(assunto) && !String.IsNullOrEmpty(nota))
            {
                if (nota.Length > 2) //Verificar o texto da nota
                {
                    //Função pra adicionar no banco de dados
                    return 1; //Nota adicionada
                }
                else
                {
                    return -2; //Nota inserida errada
                }
            }
            else
            {
                return -1; //Algum dos campos vazio
            }
        }
    }

}

