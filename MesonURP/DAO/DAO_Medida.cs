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
        public string SelectMedida(int IdInsumo)
        {
            string medida = "";
            try
            {
                SqlCommand unComando = new SqlCommand("SP_Listar_Medida", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                unComando.Parameters.AddWithValue("@I_idInsumo", IdInsumo);

                SqlDataReader dReader = unComando.ExecuteReader();
                if (dReader.Read())
                {
                    medida = dReader["Medida"].ToString();
                }
                conexion.Close();
                return medida;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
