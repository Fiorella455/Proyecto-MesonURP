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
        public void getUsuario(Dto_Usuario objUsuario)
        {
            try
            {
                conexion.Open();
                SqlCommand _Com = new SqlCommand("SP_Obtener_UidUsuario", conexion);
                _Com.CommandType = CommandType.StoredProcedure;
                _Com.Parameters.Add(new SqlParameter("@usuario", objUsuario.U_Correo));
                SqlDataReader reader = _Com.ExecuteReader();
                //_Com.ExecuteNonQuery();

                if (reader.Read())
                {
                    objUsuario.U_idUsuario = reader.GetInt32(0);
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void getNomApellUsuario(Dto_Usuario objUsuario)
        {
            try
            {
                conexion.Open();
                SqlCommand _Com = new SqlCommand("SP_Select_NomApell_Usuario", conexion);
                _Com.CommandType = CommandType.StoredProcedure;
                _Com.Parameters.Add(new SqlParameter("@usuario", objUsuario.U_idUsuario));
                SqlDataReader reader = _Com.ExecuteReader();

                if (reader.Read())
                {
                    objUsuario.U_Nombre = reader.GetString(0);
                    objUsuario.U_APaterno = reader.GetString(1);
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Consultar_Usuarios()
        {
            conexion.Open();
            DataSet ds = new DataSet();
            SqlCommand comando = new SqlCommand("SP_Consultar_Usuarios", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);
            conexion.Close();
            return ds;
        }
        public Dto_Usuario Consultar_Usuario_ID(int i)
        {
            conexion.Open();
            Dto_Usuario u = new Dto_Usuario();
            SqlCommand comando = new SqlCommand("SP_Consultar_Usuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@U_idUsuario", i);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                u.U_idUsuario = i;
                u.U_Nombre = reader[1].ToString();
                u.U_APaterno = reader[2].ToString();
                u.U_AMaterno = reader[3].ToString();
                u.U_Celular = reader[4].ToString();
                u.U_Correo = reader[5].ToString();
                u.U_Direccion = reader[6].ToString();
                u.U_FechaNacimiento = Convert.ToDateTime(reader[7]);
                u.U_Sexo = reader[8].ToString();
                u.U_Contraseña = reader[9].ToString();
                u.U_Dni = reader[10].ToString();
                u.TU_idTipoUsuario = Convert.ToInt32(reader[11]);
                u.EU_idEstadoUsuario = Convert.ToInt32(reader[12]);
                u.TD_idTipoDocumento = Convert.ToInt32(reader[13]);
            }
            conexion.Close();
            return u;
        }
        public void Registrar_Usuario(Dto_Usuario u)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Registrar_Usuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@U_Nombre", u.U_Nombre);
            comando.Parameters.AddWithValue("@U_APaterno", u.U_APaterno);
            comando.Parameters.AddWithValue("@U_AMaterno", u.U_AMaterno);
            comando.Parameters.AddWithValue("@U_Celular", u.U_Celular);
            comando.Parameters.AddWithValue("@U_Correo", u.U_Correo);
            comando.Parameters.AddWithValue("@U_Direccion", u.U_Direccion);
            comando.Parameters.AddWithValue("@U_FechaNacimiento", u.U_FechaNacimiento);
            comando.Parameters.AddWithValue("@U_Sexo", u.U_Sexo);
            comando.Parameters.AddWithValue("@U_Contraseña", u.U_Contraseña);
            comando.Parameters.AddWithValue("@U_Dni", u.U_Dni);
            comando.Parameters.AddWithValue("@TU_idTipoUsuario", u.TU_idTipoUsuario);
            comando.Parameters.AddWithValue("@EU_idEstadoUsuario", u.EU_idEstadoUsuario);
            comando.Parameters.AddWithValue("@TD_idTipoDocumento", u.TD_idTipoDocumento);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public void Actualizar_Usuario(Dto_Usuario u)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Actualizar_Usuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@U_idUsuario", u.U_idUsuario);
            comando.Parameters.AddWithValue("@U_Nombre", u.U_Nombre);
            comando.Parameters.AddWithValue("@U_APaterno", u.U_APaterno);
            comando.Parameters.AddWithValue("@U_AMaterno", u.U_AMaterno);
            comando.Parameters.AddWithValue("@U_Celular", u.U_Celular);
            comando.Parameters.AddWithValue("@U_Correo", u.U_Correo);
            comando.Parameters.AddWithValue("@U_Direccion", u.U_Direccion);
            comando.Parameters.AddWithValue("@U_FechaNacimiento", u.U_FechaNacimiento);
            comando.Parameters.AddWithValue("@U_Sexo", u.U_Sexo);
            comando.Parameters.AddWithValue("@U_Contraseña", u.U_Contraseña);
            comando.Parameters.AddWithValue("@U_Dni", u.U_Dni);
            comando.Parameters.AddWithValue("@TU_idTipoUsuario", u.TU_idTipoUsuario);
            comando.Parameters.AddWithValue("@EU_idEstadoUsuario", u.EU_idEstadoUsuario);
            comando.Parameters.AddWithValue("@TD_idTipoDocumento", u.TD_idTipoDocumento);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public void Eliminar_Usuario(int i)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Eliminar_Usuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@U_idUsuario", i);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public bool Existe_Usuario(Dto_Usuario u)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Existe_Usuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@U_Dni", u.U_Dni);
            comando.Parameters.AddWithValue("@TD_idTipoDocumento", u.TD_idTipoDocumento);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                conexion.Close();
                return true;
            }
            else
            {
                conexion.Close();
                return false;
            }

        }
    }
}


