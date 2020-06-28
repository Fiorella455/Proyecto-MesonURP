using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAO_Insumo
    {
        SqlConnection conexion;
        public DAO_Insumo()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataTable SelectInsumo()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand unComando = new SqlCommand("SP_Listar_Insumo", conexion);
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
        public DataTable SelectInsumos(string nombreInsumo)
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_Buscar_Insumo", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.AddWithValue("@nombreInsumo", nombreInsumo);
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SelectDashboard()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand unComando = new SqlCommand("SP_Listar_Insumos_Dashboard", conexion);
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
        public DataTable consultarInsumoTable()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand unComando = new SqlCommand("SP_Consultar_InsumoTable", conexion);
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
        //----------
        public void RegistrarInsumo(DTO_Insumo objIns)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertarInsumo", conexion as SqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@I_NombreInsumo", objIns.NombreInsumo));
                cmd.Parameters.Add(new SqlParameter("@I_StockMaximo", objIns.StockMax));
                cmd.Parameters.Add(new SqlParameter("@I_StockMinimo", objIns.StockMin));
                cmd.Parameters.Add(new SqlParameter("@I_PrecioUnitario", objIns.PrecioUnitario));
                cmd.Parameters.Add(new SqlParameter("@I_CantidadTotal", objIns.CantidadTotal));
                cmd.Parameters.Add(new SqlParameter("@I_FechaVencimiento", objIns.FechaVencimiento));
                cmd.Parameters.Add(new SqlParameter("@EI_idEstadoInsumo", objIns.IdEstadoInsumo));
                cmd.Parameters.Add(new SqlParameter("@M_idMedida", objIns.Medida));
                cmd.Parameters.Add(new SqlParameter("@C_idCategoria", objIns.Idcategoria));
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
