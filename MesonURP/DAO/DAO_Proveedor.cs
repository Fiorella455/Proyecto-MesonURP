using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System.Security.Cryptography.X509Certificates;

namespace DAO
{
    public class DAO_Proveedor
    {
        SqlConnection conexion;


        public DAO_Proveedor()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        
        }
        public void Registrar_Proveedor(DTO_Proveedor proveedor)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Insertar_Proveedor", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@P_RazonSocial", proveedor.P_RazonSocial);
            comando.Parameters.AddWithValue("@P_NumeroDocumento", proveedor.P_NumeroDocumento);
            comando.Parameters.AddWithValue("@P_Direccion", proveedor.P_Direccion);
            comando.Parameters.AddWithValue("@P_NombreContacto", proveedor.P_NombreContacto);
            comando.Parameters.AddWithValue("@P_TelefonoContacto", proveedor.P_TelefonoContacto);
            comando.Parameters.AddWithValue("@P_CorreoContacto", proveedor.P_CorreoContacto);
            comando.Parameters.AddWithValue("@EP_idEstadoProveedor", proveedor.EP_idEstadoProveedor);
            comando.Parameters.AddWithValue("@TD_idTipoDocumento", proveedor.TD_idTipoDocumento);
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public void Actualizar_Proveedor(DTO_Proveedor proveedor)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Actualizar_Proveedor", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@P_idProveedor", proveedor.P_idProveedor);
            comando.Parameters.AddWithValue("@P_RazonSocial", proveedor.P_RazonSocial);
            comando.Parameters.AddWithValue("@P_NumeroDocumento", proveedor.P_NumeroDocumento);
            comando.Parameters.AddWithValue("@P_Direccion", proveedor.P_Direccion);
            comando.Parameters.AddWithValue("@P_NombreContacto", proveedor.P_NombreContacto);
            comando.Parameters.AddWithValue("@P_TelefonoContacto", proveedor.P_TelefonoContacto);
            comando.Parameters.AddWithValue("@P_CorreoContacto", proveedor.P_CorreoContacto);
            comando.Parameters.AddWithValue("@EP_idEstadoProveedor", proveedor.EP_idEstadoProveedor);
            comando.Parameters.AddWithValue("@TD_idTipoDocumento", proveedor.TD_idTipoDocumento);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public bool DAO_Consultar_Proveedor(DTO_Proveedor dto_proveedor)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Consultar_Proveedor", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_idProveedor", dto_proveedor.P_idProveedor);

            SqlDataReader reader = cmd.ExecuteReader();
            bool hayProveedor = reader.Read();
            if (hayProveedor)
            {
                //Hay registros
                dto_proveedor.P_idProveedor = (int)reader[0];
                dto_proveedor.P_RazonSocial = reader[1].ToString();
                dto_proveedor.P_NumeroDocumento= reader[2].ToString();
                dto_proveedor.P_Direccion= reader[3].ToString();
                dto_proveedor.P_NombreContacto= reader[4].ToString();
                dto_proveedor.P_TelefonoContacto= reader[5].ToString();
                dto_proveedor.P_CorreoContacto = (string)reader[6];                
                dto_proveedor.Estado = 100;
            }
            dto_proveedor.Estado = 99;
            conexion.Close();
            return hayProveedor;

        }
        public DataSet DAO_Leer_Proveedor()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Lista_Proveedores", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public DTO_Proveedor Consultar_Proveedor(int i)
        {
            DTO_Proveedor proveedor = new DTO_Proveedor();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Proveedor_ID", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@P_idProveedor", i);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                proveedor.P_idProveedor = i;
                proveedor.P_RazonSocial = reader[1].ToString();
                proveedor.P_NumeroDocumento = reader[2].ToString();
                proveedor.P_Direccion = reader[3].ToString();
                proveedor.P_NombreContacto = reader[4].ToString();
                proveedor.P_TelefonoContacto = reader[5].ToString();
                proveedor.P_CorreoContacto = reader[6].ToString();
                proveedor.EP_idEstadoProveedor = Convert.ToInt32(reader[7]);
                proveedor.TD_idTipoDocumento = Convert.ToInt32(reader[8]);
            }
            conexion.Close();
            return proveedor;
        }
        public void Eliminar_Proveedor(int i)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Eliminar_Proveedor", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@P_idProveedor", i);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public bool Hay_Proveedor(DTO_Proveedor p)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Existe_Proveedor", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@P_RazonSocial", p.P_RazonSocial);
            //comando.Parameters.AddWithValue("@P_NumeroDocumento", p.P_NumeroDocumento);
            //comando.Parameters.AddWithValue("@P_Direccion", p.P_Direccion);
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
        public bool Existe_Proveedor_OC(string rs)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_OCxProveedor",conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@P_RazonSocial", rs);
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
        public DataSet DAO_SelectProveedorxEstado()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SelectProveedorxEstado", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
    }
}
