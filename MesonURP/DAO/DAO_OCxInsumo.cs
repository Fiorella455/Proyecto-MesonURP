using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    class DAO_OCxInsumo
    {
        SqlConnection conexion;
        public void DAO_Registrar_Categoria(DTO_OCxInsumo dto_ocxinsumo)
        {

            SqlCommand cmd = new SqlCommand("SP_Insertar_OCxInsumo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@R_idInsumo", dto_ocxinsumo.R_idInsumo);
            
            cmd.Parameters.AddWithValue("@OC_idOrdenCompra", dto_ocxinsumo.OC_idOrdenCompra);
            cmd.Parameters.AddWithValue("@OCxI_Cantidad", dto_ocxinsumo.OCxI_Cantidad);
            cmd.Parameters.AddWithValue("@OCxI_PrecioTotal", dto_ocxinsumo.OCxI_PrecioTotal);


        }
    }
}
