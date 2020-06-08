using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAO
{
    public class Dao_Usuario
    {
        SqlConnection conexion;
        public Dao_Usuario()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public bool Login(Dto_Usuario objUsuario)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Iniciar_Sesion", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@correo", objUsuario.U_Correo));
                cmd.Parameters.Add(new SqlParameter("@contraseña", objUsuario.U_Contraseña));
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
        public void getPerfil(Dto_Usuario objUsuario, Dto_TipoUsuario objTipoU)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Tipo_Usuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@usuario", objUsuario.U_Correo));
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    objTipoU.TU_NombreTipoUsuario = reader.GetString(0);
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
    }
}


