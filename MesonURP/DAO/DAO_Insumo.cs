﻿using System;
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
                cmd.Parameters.Add(new SqlParameter("@I_NombreInsumo", objIns.NombreInsumo));
                cmd.Parameters.Add(new SqlParameter("@I_StockMaximo", objIns.StockMax));
                cmd.Parameters.Add(new SqlParameter("@I_StockMinimo", objIns.StockMin));
                cmd.Parameters.Add(new SqlParameter("@I_PrecioUnitario", objIns.PrecioUnitario));
                cmd.Parameters.Add(new SqlParameter("@I_CantidadTotal", objIns.CantidadTotal));
                cmd.Parameters.Add(new SqlParameter("@I_FechaVencimiento", objIns.FechaVencimiento));
                cmd.Parameters.Add(new SqlParameter("@EI_idEstadoInsumo", objIns.IdEstadoInsumo));
                cmd.Parameters.Add(new SqlParameter("@M_idMedida", objIns.Medida));
                cmd.Parameters.Add(new SqlParameter("@C_idCategoria", objIns.Idcategoria));
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarInsumo(int I_idInsumo)
        {
            try
            {
                conexion.Open();
                DataTable dtable = new DataTable();
                SqlCommand unComando = new SqlCommand("SP_Eliminar_Insumo", conexion as SqlConnection);
                unComando.CommandType = CommandType.StoredProcedure;
                unComando.Parameters.Add(new SqlParameter("@I_idInsumo", I_idInsumo));
                unComando.ExecuteNonQuery();
                unComando.Parameters.Clear();
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
                cmd.Parameters.Add(new SqlParameter("@I_idInsumo", objIns.IdInsumo));
                cmd.Parameters.Add(new SqlParameter("@I_NombreInsumo", objIns.NombreInsumo));
                cmd.Parameters.Add(new SqlParameter("@I_StockMaximo", objIns.StockMax));
                cmd.Parameters.Add(new SqlParameter("@I_StockMinimo", objIns.StockMin));
                cmd.Parameters.Add(new SqlParameter("@I_PrecioUnitario", objIns.PrecioUnitario));
                cmd.Parameters.Add(new SqlParameter("@I_CantidadTotal", objIns.CantidadTotal));
                cmd.Parameters.Add(new SqlParameter("@I_FechaVencimiento", objIns.FechaVencimiento));
                cmd.Parameters.Add(new SqlParameter("@EI_idEstadoInsumo", objIns.IdEstadoInsumo));
                cmd.Parameters.Add(new SqlParameter("@M_idMedida", objIns.Medida));
                cmd.Parameters.Add(new SqlParameter("@C_idCategoria", objIns.Idcategoria));
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
                cmd.Parameters.AddWithValue("@I_NombreInsumo", objIns.NombreInsumo);
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
    }
}
