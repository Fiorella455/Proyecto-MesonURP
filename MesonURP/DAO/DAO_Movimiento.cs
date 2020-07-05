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
        public DataTable RegistrarMovimiento(string TipoMovimiento)
        {
 
            SqlCommand unComando = new SqlCommand("SP_Registrar_Movimiento", conexion);

            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@M_TipoMovimiento", TipoMovimiento));
            DataTable dtable = new DataTable();
            SqlDataAdapter data = new SqlDataAdapter(unComando);
            conexion.Open();
            data.Fill(dtable);
            return dtable;
        }
        

    }
}
