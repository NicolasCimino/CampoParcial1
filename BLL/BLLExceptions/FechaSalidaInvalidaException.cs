using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLLExceptions
{
    public class FechaSalidaInvalidaException : Exception
    {
        public FechaSalidaInvalidaException() :base("La fecha de salida con es valida")
        {

        }
    }
}
