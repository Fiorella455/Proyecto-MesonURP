using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public class DAO_AdministrarInsumo
    {
        SqlConnection conexion;

        public DAO_AdministrarInsumo() 
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        //public DataSet ()
        //{

        //}
    }
}
