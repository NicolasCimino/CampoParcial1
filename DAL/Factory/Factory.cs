using DAL.Contracts;
using DAL.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Factory
{

	public sealed class Factory
	{
		private readonly static Factory _instance = new Factory();

		public static Factory Current
		{
			get
			{
				return _instance;
			}
		}

		private Factory()
		{
			//Implent here the initialization of your singleton
		}

		public IGenericRepository<Boleto> GetBoletoRepository() { return new BoletoRepository(); }

		public IGetAllRepository<DataSet> GetTipoBoletoRepository() { return new TipoBoletoRepository(); }
	}

}
