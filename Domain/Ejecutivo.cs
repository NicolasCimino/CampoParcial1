using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Ejecutivo : Boleto
    {
        public Ejecutivo() : base() { }

        public Ejecutivo(int numeroBoleto) : base(numeroBoleto)
        {
        }

        public override double CalcularCosto()
        {
            return base.CostoEmbarque + 9800;
        }
    }
}
