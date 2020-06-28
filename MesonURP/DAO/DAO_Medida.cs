using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public class DAO_Medida
    {
        SqlConnection conexion;
        public DAO_Medida()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataSet selectMedidas()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Select_Medida", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
    }
}
