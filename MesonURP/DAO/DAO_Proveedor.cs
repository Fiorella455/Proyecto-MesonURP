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
        DTO_Proveedor dto_proveedor;

        public DAO_Proveedor()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
            dto_proveedor = new DTO_Proveedor();
        }
        public void DAO_Registrar_Proveedor(DTO_Proveedor dto_proveedor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Insertar_Proveedor", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_idProveedor", dto_proveedor.P_idProveedor);
                cmd.Parameters.AddWithValue("@P_RazonSocial", dto_proveedor.P_RazonSocial);
                cmd.Parameters.AddWithValue("@P_NumeroDocumento", dto_proveedor.P_NumeroDocumento);
                cmd.Parameters.AddWithValue("@P_Direccion", dto_proveedor.P_Direccion);
                cmd.Parameters.AddWithValue("@P_NombreContacto", dto_proveedor.P_NombreContacto);
                cmd.Parameters.AddWithValue("@P_TelefonoContacto", dto_proveedor.P_TelefonoContacto);
                cmd.Parameters.AddWithValue("@P_CorreoContacto", dto_proveedor.P_CorreoContacto);
                cmd.Parameters.AddWithValue("@EP_idEstadoProveedor", dto_proveedor.EP_idEstadoProveedor);
            }
            catch (FormatException)
            {

            }
            finally
            {
                String.IsNullOrEmpty(dto_proveedor.P_idProveedor.ToString());
                String.IsNullOrEmpty(dto_proveedor.P_RazonSocial);
                String.IsNullOrEmpty(dto_proveedor.P_NombreContacto);
                String.IsNullOrEmpty(dto_proveedor.P_NumeroDocumento);
                String.IsNullOrEmpty(dto_proveedor.P_Direccion);
                String.IsNullOrEmpty(dto_proveedor.P_CorreoContacto);
                String.IsNullOrEmpty(dto_proveedor.P_TelefonoContacto);
                String.IsNullOrEmpty(dto_proveedor.EP_idEstadoProveedor.ToString());
                
            }
            //Buscar Proveedor por id
            
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
    }
}
