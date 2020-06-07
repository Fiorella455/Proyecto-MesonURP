using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAO_Movimiento
    {
        SqlConnection conexion;
        public DAO_Movimiento()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void RegistrarMovimiento(DTO_Movimiento objDTO)
        {
            SqlCommand unComando = new SqlCommand("SP_Registrar_Movimiento", conexion);

            conexion.Open();
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@M_TipoMovimiento", objDTO.TipoMovimiento));
            unComando.Parameters.Add(new SqlParameter("@M_FechaMovimiento", objDTO.FechaMovimiento));
            unComando.Parameters.Add(new SqlParameter("@M_UsuarioMovimiento", objDTO.UsuarioMovimiento));
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
