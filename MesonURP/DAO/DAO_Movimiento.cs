using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    class DAO_Movimiento
    {
        SqlConnection conexion;
        public DAO_Movimiento()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void MS_RegistrarMov(DTO_Movimiento objMov)
        {

            string Insertar = "INSERT T_Movimiento(M_TipoMovimiento, M_FechaMovimiento, " +
                "M_UsuarioMovimiento) VALUES(" + objMov.TipoMovimiento + ",'" + objMov.FechaMovimiento + "','" + 
                objMov.UsuarioMovimiento  + "')";
            
            SqlCommand unComando = new SqlCommand(Insertar, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
