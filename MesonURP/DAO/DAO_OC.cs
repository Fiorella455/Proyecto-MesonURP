using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_OC
    {
        SqlConnection conexion;
        public void DAO_Registrar_OC(DTO_OC dto_oc)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Insertar_OC", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OC_idOrdenCompra", dto_oc.OC_idOrdenCompra);
                cmd.Parameters.AddWithValue("@OC_TipoComprobante", dto_oc.OC_TipoComprobante);
                cmd.Parameters.AddWithValue("@OC_NumeroComprobante", dto_oc.OC_NumeroComprobante);
                cmd.Parameters.AddWithValue("@OC_TotalCompra", dto_oc.OC_TotalCompra);
                cmd.Parameters.AddWithValue("@OC_FechaEmision", dto_oc.OC_FechaEmision);
                cmd.Parameters.AddWithValue("@OC_idProveedor", dto_oc.P_idProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void DAO_Consultar_Listas_OC()
        {
             
        }
        public DataTable DAO_Consultar_OC(DTO_OC dto_oc)
        {
            try
            {

                SqlDataAdapter da = new SqlDataAdapter("SP_Consultar_OC",conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@OC_idOrdenCompra", dto_oc.OC_idOrdenCompra);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void DAO_Actualizar_OC(DTO_OC dto_oc)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Insertar_OC", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OC_idOrdenCompra", dto_oc.OC_idOrdenCompra));
                cmd.Parameters.Add(new SqlParameter("@OC_TipoComprobante", dto_oc.OC_TipoComprobante));
                cmd.Parameters.Add(new SqlParameter("@OC_NumeroComprobante", dto_oc.OC_NumeroComprobante));
                cmd.Parameters.Add(new SqlParameter("@OC_TotalCompra", dto_oc.OC_TotalCompra));
                cmd.Parameters.Add(new SqlParameter("@OC_FechaEmision", dto_oc.OC_FechaEmision));
                cmd.Parameters.Add(new SqlParameter("@P_idProveedor", dto_oc.P_idProveedor));

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
