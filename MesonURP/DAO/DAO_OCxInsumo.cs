using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class DAO_OCxInsumo
    {
        SqlConnection conexion;
        DTO_OCxInsumo dto_ocxins;

        public DAO_OCxInsumo()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
            dto_ocxins = new DTO_OCxInsumo();

        }
        public void Registrar_OCxInsumo(DTO_OCxInsumo dto_ocxinsumo)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Insertar_OCxInsumo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@I_idInsumo", dto_ocxinsumo.I_idInsumo);  
            cmd.Parameters.AddWithValue("@OC_idOrdenCompra", dto_ocxinsumo.OC_idOrdenCompra);
            cmd.Parameters.AddWithValue("@OCxI_Cantidad", dto_ocxinsumo.OCxI_Cantidad);
            cmd.Parameters.AddWithValue("@OCxI_PrecioTotal", dto_ocxinsumo.OCxI_PrecioTotal);
            cmd.ExecuteNonQuery();
            conexion.Close();

        }    
        //Borrar este metodo
        public void Actualizar_OCxInsumo(DTO_OCxInsumo dto_ocxinsumo)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualizar_OCxInsumo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@I_idInsumo", dto_ocxinsumo.I_idInsumo));
                cmd.Parameters.Add(new SqlParameter("@OC_idOrdenCompra", dto_ocxinsumo.OC_idOrdenCompra));
                cmd.Parameters.Add(new SqlParameter("@OCxI_Cantidad", dto_ocxinsumo.OCxI_Cantidad));
                cmd.Parameters.Add(new SqlParameter("@OCxI_PrecioTotal", dto_ocxinsumo.OCxI_PrecioTotal));
     
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Eliminar_InsumoxOC(int idOC, int idIns)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Eliminar_InsumoxOC", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@OC_idOrdenCompra", idOC);
            comando.Parameters.AddWithValue("@I_idInsumo", idIns);
            comando.ExecuteNonQuery();
            conexion.Close();

        }
        public DataTable Leer_Insumos_xOC(int i)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_InsumoxOC", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@OC_idOrdenCompra", i);
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }

        public DataTable Leer_InsumosxMes(int m)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ListarInsumo_OCxMes", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@mes", m);
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
    }
}
