using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

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
        public bool DAO_Consultar_Categoria(DTO_Categoria dto_categoria)
        {
           
            string Select = "SELECT * FROM T_Categoria ";
                SqlCommand unComando = new SqlCommand(Select, conexion);

                conexion.Open();
                SqlDataReader reader = unComando.ExecuteReader();
                bool hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    dto_categoria.C_NombreCategoria = (string)reader[1];
                    Estado = 99;

            }
                else Estado = 1;
                conexion.Close();

                return hayRegistros;
            

        }
        

     
       


    }
}
