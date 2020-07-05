using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
   public class DAO_Tipo_Documento
    {
        SqlConnection conexion;
        public DAO_Tipo_Documento()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DTO_Tipo_Documento Consultar_Tipo_Documento_ID(int i)
        {
            DTO_Tipo_Documento documento = new DTO_Tipo_Documento();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Tipo_Documento_ID", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@TD_idTipoDocumento", i);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                documento.TD_idTipoDocumento = i;
                documento.TD_NombreTipoDocumento = reader[1].ToString();
            }
            conexion.Close();
            return documento;
        }
        public DataSet Consultar_Tipos_Documento()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Tipos_Documento", conexion);
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
