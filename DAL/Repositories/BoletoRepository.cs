using DAL.Contracts;
using DAL.DALEXceptions;
using DAL.Tools;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DAL.Repositories
{
    internal class BoletoRepository : IGenericRepository<Boleto>
    {

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Boletos] (Boleto_ID,FechaEmision,FechaSalida,TiempoEnDias,ValorBoleto,TipoBoleto_ID) VALUES (@ID,@FechaEmision,@FechaSalida,@TiempoEnDias,@ValorBoleto,@TipoBoletoID)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[] SET () WHERE  = @";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[] WHERE  = @";
        }

        private string SelectOneStatement
        {
            get => "SELECT ,  FROM [dbo].[Boletos] WHERE  = @";
        }

        private string SelectAllStatement
        {
            get => "SELECT *   FROM [dbo].[Boletos]";
        }
        #endregion


        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }


        public void Insert(Boleto obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text,
                new SqlParameter[] { new SqlParameter("@ID", Guid.NewGuid()),
                new SqlParameter("@FechaEmision", obj.FechaEmision),
                new SqlParameter("@FechaSalida", obj.FechaSalida),
                new SqlParameter("@TiempoEnDias", obj.TiempoEnDias),
                new SqlParameter("@ValorBoleto", obj.CalcularCosto()),
                new SqlParameter("@TipoBoletoID", obj.TipoBoletoID),
                });

            }
            catch (Exception )
            {
               throw new ErrorConexionDBException();
            }
        }


        public void Update(Guid id, Boleto obj)
        {
            throw new NotImplementedException();
        }

        List<Boleto> IGenericRepository<Boleto>.GetAll()
        {
            try
            {
                List<Boleto> boletos = new List<Boleto>();

                using (var dr = SqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text))
                {
                    while (dr.Read())
                    {
                        if ((int)dr["TipoBoleto_ID"] == (int)TipoBoleto.tipos.Turista)
                        {
                            Turista turista = new Turista((int)dr["NumeroBoleto"]);
                            turista.FechaEmision = (DateTime)dr["FechaEmision"];
                            turista.FechaSalida = (DateTime)dr["FechaSalida"];
                            turista.TipoBoletoID = (int)dr["TipoBoleto_ID"];
                            turista.TiempoEnDias = (int)dr["TiempoEnDias"];
                            boletos.Add(turista);
                        }
                        if ((int)dr["TipoBoleto_ID"] == (int)TipoBoleto.tipos.Ejecutivo)
                        {
                            Ejecutivo ejecutivo = new Ejecutivo((int)dr["NumeroBoleto"]);
                            ejecutivo.FechaEmision = (DateTime)dr["FechaEmision"];
                            ejecutivo.FechaSalida = (DateTime)dr["FechaSalida"];
                            ejecutivo.TipoBoletoID = (int)dr["TipoBoleto_ID"];
                            ejecutivo.TiempoEnDias = (int)dr["TiempoEnDias"];
                            boletos.Add(ejecutivo);
                        }
                    }
                }
                return boletos;
            }
            catch (Exception)
            {

                throw new ErrorConexionDBException();
            }
        }

        Boleto IGenericRepository<Boleto>.GetOne(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
