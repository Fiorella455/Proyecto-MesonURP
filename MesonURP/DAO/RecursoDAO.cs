using DAO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DTO
{
    public class RecursoDAO
    {
        SqlConnection conexion;
        public RecursoDAO()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public bool SelectRecurso(RecursoDTO objRecurso)
        {
            string Select = "SELECT * FROM T_RECURSO WHERE VR_NombreRecurso like ('" + objRecurso.NombreRecurso + "')";

            SqlCommand unComando = new SqlCommand(Select, conexion);

            conexion.Open();

            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objRecurso.NombreRecurso = (string)reader[2];
                objRecurso.idcategoria = (int)reader[13];
                objRecurso.CantidadTotal = (int)reader[10];
                objRecurso.medida = (string)reader[12];

                objRecurso.estado = 99;
            }
            else
            {
                objRecurso.estado = 1;
            }
            conexion.Close();
            return hayRegistros;
        }
        public DataSet SelectRecursos()
        {
            string Select = "SELECT * FROM Recurso";
            SqlDataAdapter unComando = new SqlDataAdapter(Select, conexion);

            DataSet ds = new DataSet();
            unComando.Fill(ds, "Recursos");

            return ds;
        }

    }
}
