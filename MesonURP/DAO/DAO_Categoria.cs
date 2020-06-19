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
        public DataSet SelectCategorias()
        {
            string Select = "SELECT * FROM T_CATEGORIA";
            SqlDataAdapter unComando = new SqlDataAdapter(Select, conexion);

            DataSet ds = new DataSet();
            unComando.Fill(ds, "T_CATEGORIAS");

            return ds;
        }

    }
}
