using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    class DAO_OCxInsumo
    {
        SqlConnection conexion = new SqlConnection();
        public void DAO_Registrar_Categoria(DTO_OCxInsumo dto_ocxinsumo)
        {

            SqlCommand cmd = new SqlCommand("SP_Insertar_OCxInsumo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@R_idInsumo", dto_ocxinsumo.R_idInsumo);  
            cmd.Parameters.AddWithValue("@OC_idOrdenCompra", dto_ocxinsumo.OC_idOrdenCompra);
            cmd.Parameters.AddWithValue("@OCxI_Cantidad", dto_ocxinsumo.OCxI_Cantidad);
            cmd.Parameters.AddWithValue("@OCxI_PrecioTotal", dto_ocxinsumo.OCxI_PrecioTotal);

        }
        public void DAO_Actualizar_OCxInsumo(DTO_OCxInsumo dto_ocxinsumo)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualizarr_OCxInsumo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@R_idInsumo", dto_ocxinsumo.R_idInsumo));
                cmd.Parameters.Add(new SqlParameter("@OC_idOrdenCompra", dto_ocxinsumo.OC_idOrdenCompra));
                cmd.Parameters.Add(new SqlParameter("@OCxI_Cantidad", dto_ocxinsumo.OCxI_Cantidad));
                cmd.Parameters.Add(new SqlParameter("@OC_PrecioTotal", dto_ocxinsumo.OCxI_PrecioTotal));
     
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       /* public Data DAO_Leer_OCxInsumo(DTO_OCxInsumo dto_ocxinsumo)
        {
            
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualizarr_OCxInsumo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@R_idInsumo", dto_ocxinsumo.R_idInsumo));
                cmd.Parameters.Add(new SqlParameter("@OC_idOrdenCompra", dto_ocxinsumo.OC_idOrdenCompra));
                cmd.Parameters.Add(new SqlParameter("@OCxI_Cantidad", dto_ocxinsumo.OCxI_Cantidad));
                cmd.Parameters.Add(new SqlParameter("@OC_PrecioTotal", dto_ocxinsumo.OCxI_PrecioTotal));

                cmd.ExecuteNonQuery();
                conexion.Close();
            
           
            string Select = "SELECT * FROM ESPECIALIDAD";

            SqlDataAdapter unComando = new SqlDataAdapter(Select, conexion);
            DataTable dtEspecialidades = new DataTable();
            unComando.Fill(dtEspecialidades);

            var lisEspecialidades = dtEspecialidades.AsEnumerable().
                                     Select(fila => new Especialidad()
                                     {
                                         EspecialidadId = (string)fila[0],
                                         Nombre = (string)fila[1],
                                         Siglas = (string)fila[2]
                                     }).ToList();
        }
       */
    }
}
