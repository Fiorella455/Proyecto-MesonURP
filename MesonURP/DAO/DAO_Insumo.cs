using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAO_Insumo
    {
        SqlConnection conexion;
        public DAO_Insumo()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public bool MS_BuscarInsumo(DTO_Insumo objInsumo)
        {
            string Select = "SELECT R_NombreInsumo, C_idCategoria, R_CantidadTotal, M_idMedida FROM T_Insumo WHERE R_NombreInsumo like ('" + objInsumo.NombreInsumo + "')";

            SqlCommand unComando = new SqlCommand(Select, conexion);

            conexion.Open();

            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objInsumo.NombreInsumo = (string)reader[2];
                objInsumo.idcategoria = (int)reader[13];
                objInsumo.CantidadTotal = (int)reader[10];
                objInsumo.medida = (string)reader[12];
            }
            conexion.Close();
            return hayRegistros;
        }
        public DataSet SelectRecursos()
        {
            string Select = "SELECT R_NombreInsumo, C_idCategoria, R_CantidadTotal, M_idMedida FROM T_Insumo";
            SqlDataAdapter unComando = new SqlDataAdapter(Select, conexion);

            DataSet ds = new DataSet();
            unComando.Fill(ds, "T_INSUMOS");

            return ds;
        }

    }
}
