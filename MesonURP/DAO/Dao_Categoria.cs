using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using DTO;
using System;

namespace DAO
{
    public class Dao_Categoria
    {
        SqlConnection conexion;
        int Estado;
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
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Consultar_Categoria", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                DataSet dataset = new DataSet();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(dataset);
                return dataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        

     
       


    }
}
