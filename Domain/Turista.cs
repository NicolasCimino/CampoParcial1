using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Turista : Boleto
    {
        public Turista() : base()
        {

        }
        public Turista(int numeroBoleto) : base(numeroBoleto)
        {
        }

        public override double CalcularCosto()
        {
            return base.CostoEmbarque + 8400;
        }
    }
}
