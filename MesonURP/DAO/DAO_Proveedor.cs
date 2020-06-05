using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    class DAO_Proveedor
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
            cmd.Parameters.AddWithValue("@VR_NombreRecurso", dto_proveedor.P_idProveedor);
            cmd.Parameters.AddWithValue("@DR_FechaIngreso", dto_proveedor.P_RazonSocial);
            cmd.Parameters.AddWithValue("@DR_FechaSalida", dto_proveedor.P_NumeroDocumento);
            cmd.Parameters.AddWithValue("@DR_StockMaximo", dto_proveedor.P_Direccion);
            cmd.Parameters.AddWithValue("@DR_StockMinimo", dto_proveedor.P_NombreContacto);
            cmd.Parameters.AddWithValue("@DR_PrecioUnitario", dto_proveedor.P_TelefonoContacto);
            cmd.Parameters.AddWithValue("@DR_CantidadEntrada", dto_proveedor.P_CorreoContacto);
            cmd.Parameters.AddWithValue("@DR_CantidadSalida", dto_proveedor.EP_idEstadoProveedor);
           
        }  
    }
}
