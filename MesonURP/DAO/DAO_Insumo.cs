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
        DTO_Insumo dto_insumo;
        DTO_OC dto_oc;

        public DAO_Insumo()
        {
            dto_oc = new DTO_OC();
            dto_insumo = new DTO_Insumo();
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
        //----------------------------
        public DataTable consultarInsumoTable()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_Consultar_InsumoTable", conexion);
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

        public void registrarInsumo(DTO_Insumo objIns)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertarInsumo", conexion as SqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@I_NombreInsumo", objIns.VR_NombreRecurso));
                cmd.Parameters.Add(new SqlParameter("@I_StockMaximo", objIns.DR_StockMaximo));
                cmd.Parameters.Add(new SqlParameter("@I_StockMinimo", objIns.DR_StockMinimo));
                cmd.Parameters.Add(new SqlParameter("@I_PrecioUnitario", objIns.DR_PrecioUnitario));
                cmd.Parameters.Add(new SqlParameter("@I_CantidadTotal", objIns.DR_CantidadTotal));
                cmd.Parameters.Add(new SqlParameter("@I_FechaVencimiento", objIns.I_FechaVencimiento));
                cmd.Parameters.Add(new SqlParameter("@EI_idEstadoInsumo", objIns.FK_IER_EstadoRecurso));
                cmd.Parameters.Add(new SqlParameter("@M_idMedida", objIns.FK_IM_Medida));
                cmd.Parameters.Add(new SqlParameter("@C_idCategoria", objIns.FK_IC_Categoria));
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminarInsumo(DTO_Insumo objIns)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Delete_Insumo", conexion as SqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@I_idInsumo", SqlDbType.Int).Value = objIns.PK_IR_Recurso;
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void actualizarInsumo(DTO_Insumo objIns)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualizar_Insumo", conexion as SqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@I_idInsumo", objIns.PK_IR_Recurso));
                cmd.Parameters.Add(new SqlParameter("@I_NombreInsumo", objIns.VR_NombreRecurso));
                cmd.Parameters.Add(new SqlParameter("@I_StockMaximo", objIns.DR_StockMaximo));
                cmd.Parameters.Add(new SqlParameter("@I_StockMinimo", objIns.DR_StockMinimo));
                cmd.Parameters.Add(new SqlParameter("@I_PrecioUnitario", objIns.DR_PrecioUnitario));
                cmd.Parameters.Add(new SqlParameter("@I_CantidadTotal", objIns.DR_CantidadTotal));
                cmd.Parameters.Add(new SqlParameter("@I_FechaVencimiento", objIns.I_FechaVencimiento));
                cmd.Parameters.Add(new SqlParameter("@EI_idEstadoInsumo", objIns.FK_IER_EstadoRecurso));
                cmd.Parameters.Add(new SqlParameter("@M_idMedida", objIns.FK_IM_Medida));
                cmd.Parameters.Add(new SqlParameter("@C_idCategoria", objIns.FK_IC_Categoria));
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable consultarInsumo1(int I_idInsumo)
        {
            try
            {
                conexion.Open();
                SqlDataAdapter _Data = new SqlDataAdapter("SP_Consultar_Insumo1", conexion);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@I_idInsumo", I_idInsumo);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable consultarInsumo2(int I_idInsumo)
        {
            try
            {
                conexion.Open();
                SqlDataAdapter _Data = new SqlDataAdapter("SP_Consultar_Insumo2", conexion);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@I_idInsumo", I_idInsumo);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool VericarExisteNombreInsumo(DTO_Insumo objIns)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Verificar_Nombre_Insumo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@I_NombreInsumo", objIns.VR_NombreRecurso);
                cmd.ExecuteNonQuery();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {
                    conexion.Close();
                    return false;
                }
                else
                {
                    conexion.Close();
                    return true;
                }

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
        public bool DAO_Consultar_Relacion_InsumoxMxOC(int I_idInsumo)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Consultar_Relacion_InsumoxMxOC", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@I_idInsumo", I_idInsumo);
                cmd.ExecuteNonQuery();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {
                    conexion.Close();
                    return false;
                }
                else
                {
                    conexion.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAO_Consultar_Relacion_InsumoxM(int I_idInsumo)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Consultar_Relacion_InsumoxM", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@I_idInsumo", I_idInsumo);
                cmd.ExecuteNonQuery();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {
                    conexion.Close();
                    return false;
                }
                else
                {
                    conexion.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAO_Consultar_Relacion_InsumoxOC(int I_idInsumo)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Consultar_Relacion_InsumoxOC", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@I_idInsumo", I_idInsumo);
                cmd.ExecuteNonQuery();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {
                    conexion.Close();
                    return false;
                }
                else
                {
                    conexion.Close();
                    return true;
                }

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
        public bool LimiteStockMax(DTO_OCxInsumo dto_ocxi)
        {
            dto_insumo.DR_StockMaximo = Consultar_InsumoxID(dto_ocxi.I_idInsumo).DR_StockMaximo;
            dto_insumo.DR_CantidadTotal = Consultar_InsumoxID(dto_ocxi.I_idInsumo).DR_CantidadTotal;
            if (dto_ocxi.OCxI_Cantidad > dto_insumo.DR_StockMaximo || (dto_ocxi.OCxI_Cantidad + dto_insumo.DR_CantidadTotal) > dto_insumo.DR_StockMaximo)
            {
                return true;
            }
            return false;
        }
    }
}
    

