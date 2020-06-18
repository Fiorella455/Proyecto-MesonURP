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
        DTO_Insumo dto_insumo;
        
        public DAO_Insumo()
        {
            dto_insumo = new DTO_Insumo();
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void Dao_Registrar_Recurso(DTO_Insumo dto_rec)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Agregar_Recurso", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VR_NombreRecurso", dto_rec.VR_NombreRecurso);
            cmd.Parameters.AddWithValue("@DR_FechaIngreso", dto_rec.DR_FechaIngreso);
            cmd.Parameters.AddWithValue("@DR_FechaSalida", dto_rec.DR_FechaSalida);
            cmd.Parameters.AddWithValue("@DR_StockMaximo", dto_rec.DR_StockMaximo);
            cmd.Parameters.AddWithValue("@DR_StockMinimo", dto_rec.DR_StockMinimo);
            cmd.Parameters.AddWithValue("@DR_PrecioUnitario", dto_rec.DR_PrecioUnitario);
            cmd.Parameters.AddWithValue("@DR_CantidadEntrada", dto_rec.DR_CantidadEntrada);
            cmd.Parameters.AddWithValue("@DR_CantidadSalida", dto_rec.DR_CantidadSalida);
            cmd.Parameters.AddWithValue("@DR_CantidadTotal", dto_rec.DR_CantidadTotal);

            cmd.Parameters.AddWithValue("@FK_IC_Categoria", dto_rec.FK_IC_Categoria);
            cmd.Parameters.AddWithValue("@FK_IM_Medida", dto_rec.FK_IM_Medida);
            cmd.Parameters.AddWithValue("@FK_IER_EstadoRecurso", dto_rec.FK_IER_EstadoRecurso);   
            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public DataSet Dao_Leer_Insumos_Categorias(int idCategoria)
        {

            conexion.Open();
            // SqlCommand comando = new SqlCommand("SP_Consultar_Insumos_Categoria", conexion);
            SqlCommand comando = new SqlCommand("SP_Consultar_Insumos_Categoria_Minimo", conexion);
            comando.CommandType = CommandType.StoredProcedure;
             comando.Parameters.AddWithValue("@C_idCategoria", idCategoria);
                       
            comando.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);
            conexion.Close();
            return ds;

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
                insumo.FK_IER_EstadoRecurso = Convert.ToInt32(reader[6]);
                insumo.FK_IM_Medida = Convert.ToInt32(reader[7]);
                insumo.FK_IC_Categoria = Convert.ToInt32(reader[8]);
            }

            conexion.Close();
            return insumo;
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

    }
}
