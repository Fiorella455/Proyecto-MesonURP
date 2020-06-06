using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_Estado_OC
    {
        SqlConnection conexion;

        public DAO_Estado_OC()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void DAO_Registrar_Estado_OC(DTO_Estado_OC dto_estado_oc)
        {

            SqlCommand cmd = new SqlCommand("SP_Insertar_Estado_OC", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EOC_idEstadoOC", dto_estado_oc.EOC_idEstadoOC);
            cmd.Parameters.AddWithValue("@EOC_NombreEstadoOC", dto_estado_oc.EOC_NombreEstadoOC);
           

        }
    }
}
