using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Data.SqlClient;
using DTO;
using System.Security.Cryptography.X509Certificates;

namespace DAO
{
    public class DAO_Insumo
    {

        SqlConnection conexion;
        DTO_Insumo dto_insumo;
        
        public DAO_Insumo()
        {
            dto_insumo = new DTO_Insumo();
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        
        public DataSet Dao_Leer_Insumos_Categorias(int idCategoria)
        {

            conexion.Open();
            // SqlCommand comando = new SqlCommand("SP_Consultar_Insumos_Categoria", conexion);
            SqlCommand comando = new SqlCommand("SP_Consultar_Insumos_Categoria_Minimo", conexion);
            comando.CommandType = CommandType.StoredProcedure;
             comando.Parameters.AddWithValue("@C_idCategoria", idCategoria);
                       
            comando.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);
            conexion.Close();
            return ds;

        }

        public DataSet CargarInsumosOC()
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_Listar_Insumos_OC", conexion);
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

        public string SelectPrecioUnitario(int IdInsumo)
        {
            string precioUnitario = "";
            try
            {
                SqlCommand unComando = new SqlCommand("SP_Listar_precioUnitario_OC", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                unComando.Parameters.AddWithValue("@I_idInsumo", IdInsumo);

                SqlDataReader dReader = unComando.ExecuteReader();
                if (dReader.Read())
                {
                    precioUnitario = dReader["precioUnitario"].ToString();
                }
                conexion.Close();
                return precioUnitario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
