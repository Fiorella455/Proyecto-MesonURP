using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;


namespace DAO
{
    public class Dao_Recurso
    {
        SqlConnection conexion;
        public Dao_Recurso()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void Dao_Registrar_Insumo(Dto_Recurso dto_rec)
        {
            SqlCommand cmd = new SqlCommand("SP_Agregar_Recurso", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VR_NombreRecurso", dto_rec.VR_NombreRecurso);
            cmd.Parameters.AddWithValue("@DR_FechaIngreso", dto_rec.DR_FechaIngreso);
            cmd.Parameters.AddWithValue("@DR_FechaSalida", dto_rec.DR_FechaSalida);
            cmd.Parameters.AddWithValue("@DR_StockMaximo", dto_rec.DR_StockMaximo);
            cmd.Parameters.AddWithValue("@DR_StockMinimo", dto_rec.DR_StockMinimo);
            cmd.Parameters.AddWithValue("@DR_PrecioUnitario", dto_rec.DR_PrecioUnitario);
            cmd.Parameters.AddWithValue("@DR_CantidadEntrada", dto_rec.DR_CantidadEntrada);
            cmd.Parameters.AddWithValue("@DR_CantidadSalida", dto_rec.DR_CantidadSalida);
            cmd.Parameters.AddWithValue("@DR_CantidadTotal", dto_rec.DR_CantidadTotal);

            cmd.Parameters.AddWithValue("@FK_IC_Categoria", dto_rec.FK_IC_Categoria);
            cmd.Parameters.AddWithValue("@FK_IM_Medida", dto_rec.FK_IM_Medida);
            cmd.Parameters.AddWithValue("@FK_IER_EstadoRecurso", dto_rec.FK_IER_EstadoRecurso);


            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public DataSet CargarServicio(E_SolicitudxCliente _Esc)
        {
            try
            {
                _Dp.getCliente(_Ep);
                SqlDataAdapter _Data = new SqlDataAdapter("SP_Desplegable_Servicio", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.Add(new SqlParameter("@codCliente", _Esc.codCliente));

                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
