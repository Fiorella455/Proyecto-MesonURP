using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System;

namespace DAO
{
    public class Dao_Categoria
    {
         SqlConnection conexion;

        public Dao_Categoria()
        {

            conexion = new SqlConnection(ConexionBD.CadenaConexion); 

        }
        public DataSet selectCategorias()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Select_Categoria", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public void DAO_Registrar_Categoria(DTO_Categoria dto_categoria)
        {
            
                SqlCommand cmd = new SqlCommand("SP_Insertar_Categoria", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@C_idCategoria", dto_categoria.C_idCategoria);
                cmd.Parameters.AddWithValue("@C_NombreCategoria", dto_categoria.C_NombreCategoria);
                cmd.Parameters.AddWithValue("@C_Descripcion", dto_categoria.C_Descripcion);
      
        }
        public DataSet DAO_Leer_Categorias()
        {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Consultar_Categoria", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
               
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                data.Fill(dataset);
                conexion.Close();
                return dataset;
        }

        public DataTable DAO_InsumosxCategoria(int C_idCategoria)
        {
            try
            {
                conexion.Open();
                SqlDataAdapter _Data = new SqlDataAdapter("SP_Consultar_InsumosxCategoria", conexion);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@C_idCategoria", C_idCategoria);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
