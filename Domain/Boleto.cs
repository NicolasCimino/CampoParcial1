using System;


namespace Domain
{
    public abstract class Boleto
    {
        private double _costoEmbarque;
        private DateTime _fechaSalida;
        private int _numero;
        private int _tiempoEnDias;
        private DateTime _fechaEmision;
        private int _tipoBoletoID;

        public double CostoEmbarque { get { return _costoEmbarque;} set { _costoEmbarque = value; } }
        public DateTime FechaSalida { get { return _fechaSalida;} set { _fechaSalida = value;} }
        public int Numero { get { return _numero;} }
        public int TiempoEnDias { get {  return _tiempoEnDias; } set { _tiempoEnDias = value; } }
        public DateTime FechaEmision { get { return _fechaEmision; } set { _fechaEmision=value; } }
        public int TipoBoletoID { get { return _tipoBoletoID; } set { _tipoBoletoID = value; } }

        public Boleto()
        {
            this._costoEmbarque = 9950;
        }
        public Boleto( int numeroBoleto) 
        {
            this._numero = numeroBoleto;
            this._costoEmbarque = 9950;
        }

        public DateTime CalcularRegreso() { return _fechaSalida.AddDays(_tiempoEnDias); }
        public abstract double CalcularCosto();
             
    }
}
