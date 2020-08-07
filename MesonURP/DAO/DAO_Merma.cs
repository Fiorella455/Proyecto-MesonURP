using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_Merma
    {
        SqlConnection conexion;
        

        public DAO_Merma()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataSet selectInsumosEgresados(DateTime MxI_FechaMovimiento)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Listar_Insumo_Merma", conexion);
            cmd.Parameters.AddWithValue("@MxI_FechaMovimiento", MxI_FechaMovimiento);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }

        public DataTable consultaMerma()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_Consultar_Mermas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BuscarInsumoMerma(string I_NombreInsumo)
        {
            try{ 
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Buscar_Insumo_Merma", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@I_NombreInsumo", I_NombreInsumo);
                DataSet dSet = new DataSet();
                cmd.Fill(dSet);
                return dSet.Tables[0];
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //SP_ContarEgresos
        public string mostrarEgresos(int I_idInsumo, DateTime MxI_FechaMovimiento)
        {
            string egresos = "";
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ContarEgresos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@I_idInsumo", I_idInsumo);
                cmd.Parameters.AddWithValue("@MxI_FechaMovimiento", MxI_FechaMovimiento);
                cmd.ExecuteNonQuery();
                SqlDataReader dReader = cmd.ExecuteReader();
                if (dReader.Read())
                {
                    egresos = dReader["MovxInsumo"].ToString();
                }
                conexion.Close();
                return egresos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public string sumarEgresos(int I_idInsumo, DateTime MxI_FechaMovimiento)
        {
            string sumaegresos = "";
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_SumaEgresos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@I_idInsumo", I_idInsumo);
                cmd.Parameters.AddWithValue("@MxI_FechaMovimiento", MxI_FechaMovimiento);
                cmd.ExecuteNonQuery();
                SqlDataReader dReader = cmd.ExecuteReader();
                if (dReader.Read())
                {
                    sumaegresos = dReader["MovxInsumo"].ToString();
                }
                conexion.Close();
                return sumaegresos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string PesoRendimiento(int I_idInsumo, decimal M_PesoMerma)
        {
            string pesorendimiento = "";
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_PesoRendimiento", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@I_idInsumo", I_idInsumo);
                cmd.Parameters.AddWithValue("@M_PesoMerma", M_PesoMerma);
                cmd.ExecuteNonQuery();
                SqlDataReader dReader = cmd.ExecuteReader();
                if (dReader.Read())
                {
                    pesorendimiento = dReader["Merma"].ToString();
                }
                conexion.Close();
                return pesorendimiento;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void AgregarMerma(DTO_Merma objMerma)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Agregar_Insumo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@M_Fecha", objMerma.M_Fecha));
                cmd.Parameters.Add(new SqlParameter("@M_PesoMerma", objMerma.M_PesoMerma));
                cmd.Parameters.Add(new SqlParameter("@M_PesoRendimiento", objMerma.M_PesoRendimiento));
                cmd.Parameters.Add(new SqlParameter("@M_Observacion", objMerma.M_Observacion));
                cmd.Parameters.Add(new SqlParameter("@MxI_idMovimientoxInsumo", objMerma.MxI_idMovimientoxInsumo));
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActualizarMerma(DTO_Merma objMerma)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualizar_Merma", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@T_idMerma", objMerma.T_idMerma));
                cmd.Parameters.Add(new SqlParameter("@M_PesoMerma", objMerma.M_PesoMerma));
                cmd.Parameters.Add(new SqlParameter("@M_PesoRendimiento", objMerma.M_PesoRendimiento));
                cmd.Parameters.Add(new SqlParameter("@M_Observacion", objMerma.M_Observacion));
                
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string SelectMovXIn(int I_idInsumo)
        {
            string movXin = "";
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Select_MovxInsumo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@I_idInsumo", I_idInsumo);
                cmd.ExecuteNonQuery();
                SqlDataReader dReader = cmd.ExecuteReader();
                if (dReader.Read())
                {
                    movXin = dReader["MovxI"].ToString();
                }
                conexion.Close();
                return movXin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarMerma(DTO_Merma objMerma)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Eliminar_Merma", conexion as SqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@T_idMerma", SqlDbType.Int).Value = objMerma.T_idMerma;
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DTO_Merma Consultar_Merma (int i)
        {
            DTO_Merma merma = new DTO_Merma();
            //DTO_Insumo insumo = new DTO_Insumo();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_MermaxID", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@T_idMerma", i);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {

                merma.T_idMerma = i;
                merma.M_Fecha = Convert.ToDateTime(reader[0]);
                //insumo.VR_NombreRecurso = reader[1].ToString();
                //insumo.DR_CantidadTotal = Convert.ToDecimal(reader[2].ToString());
                merma.M_PesoMerma = Convert.ToDecimal(reader[1]);
                merma.M_PesoRendimiento = Convert.ToDecimal(reader[2]);
                merma.M_Observacion = reader[3].ToString();

            }
            conexion.Close();
            return merma;
        }
        public int IdInsumo(DTO_Insumo dto_insumo)
        {
            string nombre = dto_insumo.VR_NombreRecurso;
            int a = dto_insumo.PK_IR_Recurso;
            try
            {
                conexion.Open();
                SqlCommand _Com = new SqlCommand("SP_Id_DeInsumo", conexion);
                _Com.CommandType = CommandType.StoredProcedure;
                _Com.Parameters.AddWithValue("@I_NombreInsumo", nombre);
                _Com.ExecuteNonQuery();
                SqlDataReader reader = _Com.ExecuteReader();
                //_Com.ExecuteNonQuery();

                if (reader.Read())
                {
                    dto_insumo.PK_IR_Recurso = reader.GetInt32(0);
                }
                conexion.Close();
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string MostrarMedida(int I_idInsumo)
        {
            string medida = "";
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_MEDIDA_INSUMO", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@I_idInsumo", I_idInsumo);
                cmd.ExecuteNonQuery();
                SqlDataReader dReader = cmd.ExecuteReader();
                if (dReader.Read())
                {
                    medida = dReader["Medida"].ToString();
                }
                conexion.Close();
                return medida;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //SP_ContarEgresos
    }
}
