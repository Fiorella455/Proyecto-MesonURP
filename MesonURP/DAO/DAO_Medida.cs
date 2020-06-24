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
        public DTO_Medida Consultar_MedidaxInsumo(int i)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_MedidaxInsumo", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@I_idInsumo", i);
            comando.ExecuteNonQuery();
            DTO_Medida medida = new DTO_Medida();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                medida.M_idMedida = Convert.ToInt32(reader[0]);
                medida.M_NombreMedida = reader[1].ToString();
            }
            conexion.Close();
            return medida;

        }
    }
}
