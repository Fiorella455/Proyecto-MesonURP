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

        public DAO_OCxInsumo()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);

        }
        public void Registrar_OCxInsumo(DTO_OCxInsumo dto_ocxinsumo)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Insertar_OCxInsumo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@I_idInsumo", dto_ocxinsumo.R_idInsumo);  
            cmd.Parameters.AddWithValue("@OC_idOrdenCompra", dto_ocxinsumo.OC_idOrdenCompra);
            cmd.Parameters.AddWithValue("@OCxI_Cantidad", dto_ocxinsumo.OCxI_Cantidad);
            cmd.Parameters.AddWithValue("@OCxI_PrecioTotal", dto_ocxinsumo.OCxI_PrecioTotal);
            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public void Actualizar_OCxInsumo(DTO_OCxInsumo dto_ocxinsumo)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualizar_OCxInsumo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@R_idInsumo", dto_ocxinsumo.R_idInsumo));
                cmd.Parameters.Add(new SqlParameter("@OC_idOrdenCompra", dto_ocxinsumo.OC_idOrdenCompra));
                cmd.Parameters.Add(new SqlParameter("@OCxI_Cantidad", dto_ocxinsumo.OCxI_Cantidad));
                cmd.Parameters.Add(new SqlParameter("@OC_PrecioTotal", dto_ocxinsumo.OCxI_PrecioTotal));
     
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
    }
}
