using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public class DAO_Categoria
    {
        SqlConnection conexion;
        public DAO_Categoria()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
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
