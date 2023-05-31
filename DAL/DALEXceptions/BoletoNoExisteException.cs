using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLLExceptions
{
    public class BoletoNoExisteException : Exception
    {
        public BoletoNoExisteException() : base("No se encontro el boleto")
        {
            
        }
    }
}
