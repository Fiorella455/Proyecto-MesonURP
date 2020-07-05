using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Data.SqlClient;
using DTO;
using System.Security.Cryptography.X509Certificates;

namespace DAO
{
    public class DAO_Insumo
    {
        SqlConnection conexion;
       
        public DAO_Insumo()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataSet CargarInsumosOC()
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_Listar_Insumos_OC", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SelectInsumo()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand unComando = new SqlCommand("SP_Listar_Insumo", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter data = new SqlDataAdapter(unComando);
                data.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SelectInsumos(string nombreInsumo)
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_Buscar_Insumo", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.AddWithValue("@nombreInsumo", nombreInsumo);
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SelectDashboard()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand unComando = new SqlCommand("SP_Listar_Insumos_Dashboard", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter data = new SqlDataAdapter(unComando);
                data.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SelectPrecioUnitario(int IdInsumo)
        {
            string precioUnitario = "";
            try
            {
                SqlCommand unComando = new SqlCommand("SP_Listar_PrecioUnitario", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                unComando.Parameters.AddWithValue("@I_idInsumo", IdInsumo);

                SqlDataReader dReader = unComando.ExecuteReader();
                if (dReader.Read())
                {
                    precioUnitario = dReader["PrecioUnitario"].ToString();
                }
                conexion.Close();
                return precioUnitario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DTO_Insumo Consultar_InsumoxID(int i)
        {
            DTO_Insumo insumo = new DTO_Insumo();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_InsumoxID", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@I_idInsumo", i);
            comando.ExecuteNonQuery();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                insumo.PK_IR_Recurso = Convert.ToInt32(reader[0]);
                insumo.VR_NombreRecurso = Convert.ToString(reader[1]);
                insumo.DR_StockMaximo = Convert.ToDecimal(reader[2]);
                insumo.DR_StockMinimo = Convert.ToDecimal(reader[3]);
                insumo.DR_PrecioUnitario = Convert.ToDecimal(reader[4]);
                insumo.DR_CantidadTotal = Convert.ToDecimal(reader[5]);
                insumo.FK_IER_EstadoRecurso = Convert.ToInt32(reader[7]);
                insumo.FK_IM_Medida = Convert.ToInt32(reader[8]);
                insumo.FK_IC_Categoria = Convert.ToInt32(reader[9]);
            }

            conexion.Close();
            return insumo;
        }
        public DTO_Insumo Consultar_InsumoxID(int i)
        {
            DTO_Insumo insumo = new DTO_Insumo();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_InsumoxID", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@I_idInsumo", i);
            comando.ExecuteNonQuery();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                insumo.PK_IR_Recurso = Convert.ToInt32(reader[0]);
                insumo.VR_NombreRecurso = Convert.ToString(reader[1]);
                insumo.DR_StockMaximo = Convert.ToDecimal(reader[2]);
                insumo.DR_StockMinimo = Convert.ToDecimal(reader[3]);
                insumo.DR_PrecioUnitario = Convert.ToDecimal(reader[4]);
                insumo.DR_CantidadTotal = Convert.ToDecimal(reader[5]);
                insumo.FK_IER_EstadoRecurso = Convert.ToInt32(reader[7]);
                insumo.FK_IM_Medida = Convert.ToInt32(reader[8]);
                insumo.FK_IC_Categoria = Convert.ToInt32(reader[9]);
            }

            conexion.Close();
            return insumo;
        }

    }
}
