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

        public DAO_EstadoOCxOC()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void Registrar_Estado_OCxOC(DTO_Estado_OCxOC dto_estadoOCxOC)
        {

            SqlCommand cmd = new SqlCommand("SP_Insertar_EstadoOCxOC", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@EOC_idEstadoOC", dto_estadoOCxOC.EOC_idEstadoOC);
            cmd.Parameters.AddWithValue("@OC_idOrdenCompra", dto_estadoOCxOC.OC_idOrdenCompra);
            cmd.Parameters.AddWithValue("@EOC_FechaRegistro", dto_estadoOCxOC.EOCxOC_FechaRegistro);
            cmd.Parameters.AddWithValue("@OC_UsuarioRegistrado", dto_estadoOCxOC.OC_idOrdenCompra);
        }
        public void Actualizar_Estado_OCxOC(DTO_Estado_OCxOC oc)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Actualizar_Estado_OCxOC", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@EOC_idEstadoOC", oc.EOC_idEstadoOC);
            comando.Parameters.AddWithValue("@OC_idOrdenCompra", oc.OC_idOrdenCompra);
            comando.Parameters.AddWithValue("@EOCxOC_FechaRegistro", oc.EOCxOC_FechaRegistro);
            comando.Parameters.AddWithValue("@EOCxOC_UsuarioRegistro", oc.EOCxOC_UsuarioRegistro);

            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
