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
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Insertar_Estado_OCxOC", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EOC_idEstadoOC", dto_estadoOCxOC.EOC_idEstadoOC);
            cmd.Parameters.AddWithValue("@OC_idOrdenCompra", dto_estadoOCxOC.OC_idOrdenCompra);
            cmd.Parameters.AddWithValue("@EOCxOC_FechaRegistro", dto_estadoOCxOC.EOCxOC_FechaRegistro);
            cmd.Parameters.AddWithValue("@EOCxOC_UsuarioRegistro", dto_estadoOCxOC.EOCxOC_UsuarioRegistro);
            cmd.ExecuteNonQuery();
            conexion.Close();
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

        public DTO_Estado_OC Consultar_Estado_OCxOC(int i)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Estado_OC_Actual", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@OC_idOrdenCompra", i);
            comando.ExecuteNonQuery();
            DTO_Estado_OC dto_estado_oc = new DTO_Estado_OC();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                dto_estado_oc.EOC_idEstadoOC = Convert.ToInt32(reader[0]);
                dto_estado_oc.EOC_NombreEstadoOC = Convert.ToString(reader[1]);
            }
            conexion.Close();
            return dto_estado_oc;
        }
       

    }
}
