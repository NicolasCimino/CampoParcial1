using BLL.BLLExceptions;
using DAL.Contracts;
using DAL.Factory;
using Domain;
using System;
using System.Collections.Generic;


namespace BLL.BLLServices
{

	public sealed class BoletoServices
	{
		private readonly static BoletoServices _instance = new BoletoServices();

		public static BoletoServices Current
		{
			get
			{
				return _instance;
			}
		}

		private BoletoServices()
		{
			//Implent here the initialization of your singleton
		}

		IGenericRepository<Boleto> boletoRepository = Factory.Current.GetBoletoRepository();

		public bool Agregar(Boleto boleto ) 
		{
			try
			{
				if( boleto.FechaSalida.Date < boleto.FechaEmision.Date ) 
				{
					throw new FechaSalidaInvalidaException();
				}
                boletoRepository.Insert(boleto);
                return true;
            }
			catch (Exception ex)
			{

				throw ex;
			}
			
		}

		public List<Boleto> ListarTodos() 
		{
 
			return boletoRepository.GetAll();

        }
	}

}
