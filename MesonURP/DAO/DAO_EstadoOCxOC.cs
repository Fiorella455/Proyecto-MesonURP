using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;


namespace DAO
{
    public class DAO_EstadoOCxOC
    {
        SqlConnection conexion;
        public void DAO_Registrar_Categoria(DTO_Estado_OCxOC dto_estadoOCxOC)
        {

            SqlCommand cmd = new SqlCommand("SP_Insertar_EstadoOCxOC", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@EOC_idEstadoOC", dto_estadoOCxOC.EOC_idEstadoOC);
            cmd.Parameters.AddWithValue("@OC_idOrdenCompra", dto_estadoOCxOC.OC_idOrdenCompra);
            cmd.Parameters.AddWithValue("@EOC_FechaRegistro", dto_estadoOCxOC.EOCxOC_FechaRegistro);
            cmd.Parameters.AddWithValue("@OC_UsuarioRegistrado", dto_estadoOCxOC.OC_idOrdenCompra);


        }
    }
}
