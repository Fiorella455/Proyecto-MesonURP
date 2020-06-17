using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_Medida
    {
        SqlConnection conexion;

        public DAO_Medida()
        {

            conexion = new SqlConnection(ConexionBD.CadenaConexion);

        }
        public DataSet Leer_Medida()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Consultar_Medida", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            data.Fill(dataset);
            return dataset;
        }
    }
}
