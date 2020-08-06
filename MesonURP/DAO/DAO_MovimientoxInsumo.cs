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
        DTO_Insumo dto_insumo;
        public DAO_MovimientoxInsumo()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
            dto_insumo = new DTO_Insumo();
        }
        public void RegistarMovimientoxInsumo(DTO_MovimientoxInsumo objDTO)
        {
            try
            {
                conexion.Open();
                SqlCommand unComando = new SqlCommand("SP_Registrar_MovimientoxInsumo", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                unComando.Parameters.Add(new SqlParameter("@MxI_Cantidad", objDTO.Cantidad));
                unComando.Parameters.Add(new SqlParameter("@MxI_FechaMovimiento", objDTO.FechaMovimiento));   
                unComando.Parameters.Add(new SqlParameter("@I_idInsumo", objDTO.IdInsumo));
                unComando.Parameters.Add(new SqlParameter("@M_idMovimiento", objDTO.IdMovimiento));
                unComando.Parameters.Add(new SqlParameter("@U_idUsuario", objDTO.IdUsuarioMovimiento));
                unComando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
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
        public string StockMin(int IdInsumo)
        {
            string stockmin = "";
            try
            {
                SqlCommand unComando = new SqlCommand("SP_Stock_min", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                unComando.Parameters.AddWithValue("@I_idInsumo", IdInsumo);

                SqlDataReader dReader = unComando.ExecuteReader();
                if (dReader.Read())
                {
                    stockmin = dReader["StockMin"].ToString();
                }
                conexion.Close();
                return stockmin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string StockMax(int IdInsumo)
        {
            string stockmax = "";
            try
            {
                SqlCommand unComando = new SqlCommand("SP_Stock_max", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                unComando.Parameters.AddWithValue("@I_idInsumo", IdInsumo);

                SqlDataReader dReader = unComando.ExecuteReader();
                if (dReader.Read()) {
                    stockmax = dReader["StockMax"].ToString();
                }
                conexion.Close();
                return stockmax;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ID_Movimiento_Max()
        {
            int id;
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Movimiento_Mayor", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            comando.ExecuteNonQuery();
            conexion.Close();
            id = Convert.ToInt32(comando.Parameters["@id"].Value);
            conexion.Close();
            return id;
        }
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
        public DataTable ConsultarMovimientoxInsumo(string busqueda)
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand unComando = new SqlCommand("SP_ConsultarMovimientosXInsumo", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                unComando.Parameters.Add("@busqueda", SqlDbType.Text).Value = busqueda;
                SqlDataAdapter data = new SqlDataAdapter(unComando);
                data.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BuscarMovimientoxInsumoTipo(int tipo)
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_BuscarxTipoMovimientosXInsumo", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarMovimientoxInsumoxMes(int Mes)
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_ListarMovimientoxMes", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.AddWithValue("@Mes", Mes);
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SelectListMU()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand unComando = new SqlCommand("SP_Cantidad_Movimiento_Usuario", conexion);
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
    }
}
