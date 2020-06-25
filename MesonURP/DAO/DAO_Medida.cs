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
    }
}
