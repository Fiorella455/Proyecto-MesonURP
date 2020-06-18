using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Data.SqlClient;
using DTO;
using System.Security.Cryptography.X509Certificates;

namespace DAO
{
    public class DAO_Insumo
    {

        SqlConnection conexion;
        DTO_Insumo dto_insumo;
        
        public DAO_Insumo()
        {
            dto_insumo = new DTO_Insumo();
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void Dao_Registrar_Recurso(DTO_Insumo dto_rec)
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
        public DataSet Dao_Leer_Insumos_Categorias(int idCategoria)
        {

            conexion.Open();
            // SqlCommand comando = new SqlCommand("SP_Consultar_Insumos_Categoria", conexion);
            SqlCommand comando = new SqlCommand("SP_Consultar_Insumos_Categoria_Minimo", conexion);
            comando.CommandType = CommandType.StoredProcedure;
             comando.Parameters.AddWithValue("@C_idCategoria", idCategoria);
                       
            comando.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);
            return ds;

        }
        public bool DAO_Leer_PrecioUxInsumo(DTO_Insumo dto_insumo)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Consultar_PrecioU", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@I_idInsumo", dto_insumo.PK_IR_Recurso);
            SqlDataReader reader = cmd.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                dto_insumo.DR_PrecioUnitario= (int)reader[4];      
            }
            conexion.Close();
            return hayRegistros;
        }

    }
}
