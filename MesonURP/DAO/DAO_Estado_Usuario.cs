using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
   public class DAO_Estado_Usuario
    {
        SqlConnection conexion;
        public DAO_Estado_Usuario()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public Dto_EstadoUsuario Consultar_Estado_Usuario_ID(int i)
        {
            Dto_EstadoUsuario estado = new Dto_EstadoUsuario();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Estado_Usuario_ID", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@EU_idEstadoUsuario", i);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                estado.EU_idEstadoUsuario = i;
                estado.EU_NombreEstadoUsuario = reader[1].ToString();
            }
            conexion.Close();
            return estado;
        }
        public DataSet Consultar_Estados_Usuario()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Estados_Usuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);
            conexion.Close();
            return ds;
        }
    }
}
