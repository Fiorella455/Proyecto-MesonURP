using System;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class Dao_Categoria
    {
        SqlConnection conexion;
        public void DAO_Registrar_Categoria(DTO_Categoria dto_categoria)
        {
            
                SqlCommand cmd = new SqlCommand("SP_Insertar_Categoria", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@C_idCategoria", dto_categoria.C_idCategoria);
                cmd.Parameters.AddWithValue("@C_NombreCategoria", dto_categoria.C_NombreCategoria);
                cmd.Parameters.AddWithValue("@C_Descripcion", dto_categoria.C_Descripcion);
      
        }
       


    }
}
