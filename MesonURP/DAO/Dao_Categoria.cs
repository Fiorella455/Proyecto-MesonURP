using System;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class Dao_Categoria
    {
        SqlConnection conexion;
        public Dao_Categoria()
        {

            conexion = new SqlConnection(ConexionBD.CadenaConexion);

        }
        public void Ingresar_Categoria(Dto_Categoria dto_cat)
        {

            string Insert = "INSERT T_Categoria(C_idCategoria, C_NombreCategoria, C_Descripcion) VALUES('" + dto_cat.idCategoria + "', '" + dto_cat.NombreCategoria + "', '" + dto_cat.Descripcion + "')";
            SqlCommand sqlCommand = new SqlCommand(Insert, conexion);
            conexion.Open();
            sqlCommand.ExecuteNonQuery();
            conexion.Close();
        }
        public bool Seleccionar_Categoria(Dto_Categoria dto_cat)
        {
            string Select = "SELECT * FROM Libros WHERE  C_idCategoria= '" + dto_cat.idCategoria + "'";
              
            SqlCommand command = new SqlCommand(Select, conexion);

            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                
                dto_cat.idCategoria = (int)reader[0];
                dto_cat.NombreCategoria = (string)reader[1];
                dto_cat.Descripcion = (string)reader[2];

            }
           
            // Tener en cuanto que no pueden haber categoria regisrada
            conexion.Close();

            return hayRegistros;


        }


    }
}
