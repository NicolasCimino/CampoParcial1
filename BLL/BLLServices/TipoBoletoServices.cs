using DAL.Contracts;
using DAL.Factory;
using System;
using System.Data;
using System.Data.SqlClient;


namespace BLL.BLLServices
{

	public sealed class TipoBoletoServices
	{
		private readonly static TipoBoletoServices _instance = new TipoBoletoServices();

		public static TipoBoletoServices Current
		{
			get
			{
				return _instance;
			}
		}

		private TipoBoletoServices()
		{
			//Implent here the initialization of your singleton
		}

		IGetAllRepository<DataSet> tipoBoletoRepository = Factory.Current.GetTipoBoletoRepository(); 

		public DataSet GetAll() 
		{
			try 
			{
                return tipoBoletoRepository.GetAll();
            }
			catch(Exception ex) 
			{
				throw ex;
			}
			
		}
	}

}
