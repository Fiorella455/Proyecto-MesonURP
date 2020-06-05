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
        public void MS_RegistrarMov(DTO_Movimiento objMov)
        {
            SqlCommand unComando = new SqlCommand("SP_Registrar_Movimiento", conexion);

            conexion.Open();
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@M_TipoMovimiento", objMov.TipoMovimiento));
            unComando.Parameters.Add(new SqlParameter("@M_FechaMovimiento", objMov.FechaMovimiento));
            unComando.Parameters.Add(new SqlParameter("@M_UsuarioMovimiento", objMov.UsuarioMovimiento));
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
