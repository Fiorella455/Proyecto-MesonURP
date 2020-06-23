using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_MovimientoxInsumo
    {

        SqlConnection conexion;
        DTO_MovimientoxInsumo dto_movxinsumo;

        public DAO_MovimientoxInsumo()
        {
            dto_movxinsumo = new DTO_MovimientoxInsumo();
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void Dao_Registrar_MovxInsumo(DTO_MovimientoxInsumo dto_movxinsumo )
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Agregar_MovimientoxInsumo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MxI_idMovimientoxInsumo", dto_movxinsumo.MxI_idMovimientoxInsumo);
            cmd.Parameters.AddWithValue("@MxI_Cantidad", dto_movxinsumo.MxI_Cantidad);
            cmd.Parameters.AddWithValue("@MxI_FechaMovimiento", dto_movxinsumo.MxI_FechaMovimiento);
            cmd.Parameters.AddWithValue("@M_idMovimiento", dto_movxinsumo.M_idMovimiento);
            cmd.Parameters.AddWithValue("@U_idUsuario", dto_movxinsumo.U_idUsuario);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
