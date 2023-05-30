using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALEXceptions
{
    public class ErrorConexionDBException:Exception
    {
        public ErrorConexionDBException() : base("Error de conexción con DB. Comuniquese con el administrador.")
        {

        }
    }
}
