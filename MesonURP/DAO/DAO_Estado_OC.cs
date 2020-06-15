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
        public void Registrar_Estado_OC(DTO_Estado_OC dto_estado_oc)
        {

            SqlCommand cmd = new SqlCommand("SP_Insertar_Estado_OC", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EOC_idEstadoOC", dto_estado_oc.EOC_idEstadoOC);
            cmd.Parameters.AddWithValue("@EOC_NombreEstadoOC", dto_estado_oc.EOC_NombreEstadoOC);
        }
        public DataSet Leer_Estado_OC()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Estado_OC", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            return dt;
        }
    }
}
