using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;



namespace DAO
{
    public class DAO_EstadoOCxOC
    {
        SqlConnection conexion;

        public DAO_EstadoOCxOC()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void Registrar_Estado_OCxOC(DTO_Estado_OCxOC dto_estadoOCxOC)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Insertar_Estado_OCxOC", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EOC_idEstadoOC", dto_estadoOCxOC.EOC_idEstadoOC);
            cmd.Parameters.AddWithValue("@OC_idOrdenCompra", dto_estadoOCxOC.OC_idOrdenCompra);
            cmd.Parameters.AddWithValue("@EOCxOC_FechaRegistro", dto_estadoOCxOC.EOCxOC_FechaRegistro);
            cmd.Parameters.AddWithValue("@EOCxOC_UsuarioRegistro", dto_estadoOCxOC.EOCxOC_UsuarioRegistro);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void Actualizar_Estado_OCxOC(DTO_Estado_OCxOC oc)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Actualizar_Estado_OCxOC", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@EOC_idEstadoOC", oc.EOC_idEstadoOC);
            comando.Parameters.AddWithValue("@OC_idOrdenCompra", oc.OC_idOrdenCompra);
            comando.Parameters.AddWithValue("@EOCxOC_FechaRegistro", oc.EOCxOC_FechaRegistro);
            comando.Parameters.AddWithValue("@EOCxOC_UsuarioRegistro", oc.EOCxOC_UsuarioRegistro);

            comando.ExecuteNonQuery();
            if (oc.EOC_idEstadoOC ==5)
            {
                // ok...ym as abajo esta el sp 
                //del idestadooc
                //CTR_OCxInsumo o = new CTR_OCxInsumo();
                ////Stack<DTO_OCxInsumo> oci = new Stack<DTO_OCxInsumo>();
                ////comando = new SqlCommand("SP_Consultar_InsumoxOC", conexion);
                comando = new SqlCommand("SP_Consultar_InsumoxOC", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@OC_idOrdenCompra", oc.OC_idOrdenCompra);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dt);
                DTO_OCxInsumo aux = new DTO_OCxInsumo();
                //DataTable dt = o.Leer_InsumoxOC(oc.OC_idOrdenCompra);
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    object[] a = dt.Rows[i].ItemArray;
                    aux.I_idInsumo = Convert.ToInt32(a[1]);
                    //aux.OCxI_idOCxInsumo = Convert.ToInt32(a[2]);
                    aux.OC_idOrdenCompra = Convert.ToInt32(a[3]);
                    aux.OCxI_Cantidad = Convert.ToDecimal(a[4]);
                    aux.OCxI_PrecioTotal = Convert.ToDecimal(a[5]);//Los indices podrian cambiar dependiendo de como esta el sp
                    //oci.Push(aux);
                    comando = new SqlCommand("SP_Actualizar_Insumos_Recibidos", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@I_idInsumo", aux.I_idInsumo);
                    comando.Parameters.AddWithValue("@OCxI_Cantidad", aux.OCxI_Cantidad);
                    comando.ExecuteNonQuery();
                    i++;
                }
            }
            conexion.Close();

        }

        public DTO_Estado_OC Consultar_Estado_OCxOC(int i)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Estado_OC_Actual", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@OC_idOrdenCompra", i);
            comando.ExecuteNonQuery();
            DTO_Estado_OC dto_estado_oc = new DTO_Estado_OC();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                dto_estado_oc.EOC_idEstadoOC = Convert.ToInt32(reader[0]);
                dto_estado_oc.EOC_NombreEstadoOC = Convert.ToString(reader[1]);
            }
            conexion.Close();
            return dto_estado_oc;
        }
       

    }
}
