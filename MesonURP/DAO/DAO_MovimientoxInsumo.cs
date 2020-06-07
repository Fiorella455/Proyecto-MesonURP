using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public class DAO_MovimientoxInsumo
    {
        SqlConnection conexion;
        public DAO_MovimientoxInsumo()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void RegistarMovimientoxInsumo(DTO_MovimientoxInsumo objDTO)
        {
            try
            {
                conexion.Open();
                SqlCommand unComando = new SqlCommand("SP_Registrar_MovimientoxInsumo", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                unComando.Parameters.Add(new SqlParameter("@M_idMovimiento", objDTO.IdMovimiento));
                unComando.Parameters.Add(new SqlParameter("@I_idInsumo", objDTO.IdInsumo));
                unComando.Parameters.Add(new SqlParameter("@M_Cantidad", objDTO.Cantidad));
                unComando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
