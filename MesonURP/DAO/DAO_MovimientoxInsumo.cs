using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public class DAO_MovimientoxInsumo
    {
        SqlConnection conexion;
        decimal temp;
        public DAO_MovimientoxInsumo()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void RegistarMovimientoxInsumo(DTO_MovimientoxInsumo objDTO)
        {
            try
            {
                conexion.Open();
                SqlCommand unComando = new SqlCommand("SP_Registrar_MovimientoxInsumo", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                unComando.Parameters.Add(new SqlParameter("@MxI_Cantidad", objDTO.Cantidad));
                //unComando.Parameters.Add(new SqlParameter("@MxI_UsuarioMovimiento", objDTO.UsuarioMovimiento));
                unComando.Parameters.Add(new SqlParameter("@MxI_FechaMovimiento", objDTO.FechaMovimiento));   
                unComando.Parameters.Add(new SqlParameter("@I_idInsumo", objDTO.IdInsumo));
                unComando.Parameters.Add(new SqlParameter("@M_idMovimiento", objDTO.IdMovimiento));
                unComando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectMedida()
        {
            try
            {
                //SqlDataAdapter unComando = new SqlDataAdapter("Movimientos", conexion);
                SqlDataAdapter unComando = new SqlDataAdapter("SP_Listar_Medida2", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                //unComando.SelectCommand.Parameters.AddWithValue("@I_idInsumo", idInsumo);
                //unComando.SelectCommand.Parameters.AddWithValue("@I_NombreInsumo", nombreInsumo);
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet;
                //return dSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /*public DataSet SelectMedida(int idInsumo)
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_Listar_Medida", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.AddWithValue("@I_idInsumo", idInsumo);
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
               return dSet;
               //return dSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        public DataSet CargarInsumoIngreso()
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_Listar_Insumos_Por_Ingresar", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet CargarInsumoEgreso()
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_Listar_Insumos_Por_Egresar", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*public DataSet StockMin(DTO_MovimientoxInsumo objDTO)
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_Stock_min", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.AddWithValue("@I_idInsumo", objDTO.IdInsumo);
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

        public decimal StockMin(DTO_MovimientoxInsumo objDTO)
        {
            decimal tmp = 0;
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_Stock_min", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.AddWithValue("@I_idInsumo", objDTO.IdInsumo);
                SqlDataReader dReader = unComando.SelectCommand.ExecuteReader();
                //return dReader;

                while (dReader.Read())
                {
                    tmp = Convert.ToDecimal(dReader[0]);
                }
                return tmp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void StockMax(int IdInsumo)
        {
            //decimal tmp = 0;
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_Stock_max", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.AddWithValue("@I_idInsumo", IdInsumo);

                //SqlDataReader dReader = unComando.SelectCommand.ExecuteReader();
                //return dReader;

                /*  while (dReader.Read())
                  {
                      tmp = Convert.ToDecimal(dReader[0]);
                  }*/
                //return temp;
                return;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /*public decimal StockMax(DTO_MovimientoxInsumo objDTO)
        {
            decimal tmp = 0;
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_Stock_max", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.AddWithValue("@I_idInsumo", objDTO.IdInsumo);
                SqlDataReader dReader = unComando.SelectCommand.ExecuteReader();
                //return dReader;

                while (dReader.Read())
                {
                    tmp = Convert.ToDecimal(dReader[0]);
                }
                return tmp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        /*public DataSet StockMax(DTO_MovimientoxInsumo objDTO)
        {
            try
            {
                decimal tmp = 0;
                SqlDataAdapter unComando = new SqlDataAdapter("SP_Stock_max", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.AddWithValue("@I_idInsumo", objDTO.IdInsumo);
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        public void ActualizarStockIngreso(DTO_MovimientoxInsumo objDTO)
        {
            try
            {
                conexion.Open();
                SqlCommand unComando = new SqlCommand("SP_UpdateStockIngreso", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                unComando.Parameters.Add(new SqlParameter("@MxI_Cantidad", objDTO.Cantidad));
                unComando.Parameters.Add(new SqlParameter("@I_idInsumo", objDTO.IdInsumo));
                unComando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActualizarStockEgreso(DTO_MovimientoxInsumo objDTO)
        {
            try
            {
                conexion.Open();
                SqlCommand unComando = new SqlCommand("SP_UpdateStockEgreso", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                unComando.Parameters.Add(new SqlParameter("@MxI_Cantidad", objDTO.Cantidad));
                unComando.Parameters.Add(new SqlParameter("@I_idInsumo", objDTO.IdInsumo));
                unComando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarMovimientos()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand unComando = new SqlCommand("SP_ListarMovimientos", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter data = new SqlDataAdapter(unComando);
                data.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BuscarMovimientos(string busquedamov)
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_BuscarMovimiento", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.AddWithValue("@busquedamov", busquedamov);
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
