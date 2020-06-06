using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_Proveedor
    {
        SqlConnection conexion;

        public DAO_Proveedor()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void DAO_Registrar_Proveedor(DTO_Proveedor dto_proveedor)
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
    }
}
