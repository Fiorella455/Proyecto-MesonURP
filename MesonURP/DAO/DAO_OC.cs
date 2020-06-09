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

            SqlCommand cmd = new SqlCommand("SP_Insertar_OC", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OC_idOrdenCompra", dto_oc.OC_idOrdenCompra);
            cmd.Parameters.AddWithValue("@OC_TipoComprobante", dto_oc.OC_TipoComprobante);
            cmd.Parameters.AddWithValue("@OC_NumeroComprobante", dto_oc.OC_NumeroComprobante);
            cmd.Parameters.AddWithValue("@OC_TotalCompra", dto_oc.OC_TotalCompra);
            cmd.Parameters.AddWithValue("@OC_FechaEmision", dto_oc.OC_FechaEmision);
            cmd.Parameters.AddWithValue("@OC_idProveedor", dto_oc.P_idProveedor);


        }
    }
}
