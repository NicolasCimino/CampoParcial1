using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.UIExceptions
{
    public class ErrorIngresoDatos : Exception
    {
        public ErrorIngresoDatos(): base() { }
        public ErrorIngresoDatos(string message) : base("Error de ingreso de datos en " + message) 
        {
           
        }

    }
}
