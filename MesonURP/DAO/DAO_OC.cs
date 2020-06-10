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
        int estado=0;
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
        public bool DAO_Consultar__OC_2(DTO_OC dto_oc)
        {
            string Select = "SELECT * FROM T_OC WHERE T_idOrdenCompra = '" + dto_oc.OC_idOrdenCompra + "'";
            SqlCommand cmd = new SqlCommand(Select, conexion);

            conexion.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                //Hay registros
                dto_oc.OC_idOrdenCompra = (int)reader[0];
                dto_oc.OC_TipoComprobante = (string)reader[1];
                dto_oc.OC_NumeroComprobante = (string)reader[2];
                dto_oc.OC_TotalCompra = (double)reader[3];
                dto_oc.OC_FechaEmision = (DateTime)reader[4];
                dto_oc.P_idProveedor = (int)reader[5];

                estado = 100;
            }
            //No hay registros
            else estado = 99;
            conexion.Close();

            return hayRegistros;
        }
        public void DAO_Consultar_OC(DTO_OC dto_oc)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("SP_Consultar_OC",conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OC_idOrdenCompra", dto_oc.OC_idOrdenCompra);
                
               
                
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
