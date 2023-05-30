using DAL.Contracts;
using DAL.DALEXceptions;
using DAL.Tools;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;


namespace DAL.Repositories
{
    internal class TipoBoletoRepository : IGetAllRepository<DataSet>
    {
        #region Statements
        
        private string SelectAllStatement
        {
            get => "SELECT *   FROM [dbo].[TipoBoleto]";
        }
        #endregion
        public DataSet GetAll()
        {
            try 
            {
                DataSet ds = new DataSet();
                using (var dr = SqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text))
                {
                    ds.Tables.Add("tipos");
                    ds.Tables[0].Load(dr);
                }
                return ds;
            }
            catch(Exception) 
            {
                throw new ErrorConexionDBException();
            }
            
        }
    }
}
