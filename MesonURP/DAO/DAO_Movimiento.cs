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
            unComando.Parameters.Add(new SqlParameter("@M_UsuarioMovimiento", objDTO.UsuarioMovimiento));
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataSet CargarInsumoIngreso()
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_Listar_Insumos_Por_Ingresar", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.Add(new SqlParameter("@M_TipoMovimiento", "Ingresar")); //tengo dudas aqui revisar luego
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet CargarInsumoEgreso()
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_Listar_Insumos_Por_Egresar", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.Add(new SqlParameter("@M_TipoMovimiento", "Egresar")); //tengo dudas aqui revisar luego
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
