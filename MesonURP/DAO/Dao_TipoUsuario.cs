﻿using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
   public class Dao_TipoUsuario
    {
        SqlConnection conexion;
        public Dao_TipoUsuario()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public Dto_TipoUsuario Consultar_Tipo_Usuario_ID(int i)
        {
            Dto_TipoUsuario estado = new Dto_TipoUsuario();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Tipo_Usuario_ID", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@TU_idTipoUsuario", i);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                estado.TU_idTipoUsuario = i;
                estado.TU_NombreTipoUsuario = reader[1].ToString();
            }
            conexion.Close();
            return estado;
        }
        public DataSet Consultar_Tipos_Usuario()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Tipos_Usuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);
            conexion.Close();
            return ds;
        }
    }
}
 