using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;


namespace DAO
{
    public class DAO_Estado_Proveedor
    {
        SqlConnection conexion;
        public DAO_Estado_Proveedor()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DTO_Estado_Proveedor Consultar_Estado_Proveedor_ID(int i)
        {
            DTO_Estado_Proveedor estado = new DTO_Estado_Proveedor();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Estado_Proveedor_ID", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@EP_idEstadoProveedor", i);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                estado.EP_idEstadoProveedor = i;
                estado.EP_NombreEstadoProveedor = reader[1].ToString();
            }
            conexion.Close();
            return estado;
        }
        public DataSet Consultar_Estados_Proveedor()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Estados_Proveedor", conexion);
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
