using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System.Net.Mail;
using System.Net;

namespace DAO
{
    public class DAO_OC
    {
        SqlConnection conexion;
        DTO_Proveedor dto_proveedor;
        DAO_Proveedor dao_proveedor;
        DTO_OC dto_oc;
        string prueba = "";
        public DAO_OC()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
            dto_proveedor = new DTO_Proveedor();
            dao_proveedor = new DAO_Proveedor();
            dto_oc = new DTO_OC();
        }
        public void Registrar_OC(DTO_OC dto_oc)
        {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Insertar_OC", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@OC_idOrdenCompra", dto_oc.OC_idOrdenCompra);
                cmd.Parameters.AddWithValue("@OC_TipoComprobante", dto_oc.OC_TipoComprobante);
                cmd.Parameters.AddWithValue("@OC_NumeroComprobante", dto_oc.OC_NumeroComprobante);
                cmd.Parameters.AddWithValue("@OC_FormaPago", dto_oc.OC_FormaPago);
                cmd.Parameters.AddWithValue("@OC_FechaPago", dto_oc.OC_FechaPago);
                cmd.Parameters.AddWithValue("@OC_TotalCompra", dto_oc.OC_TotalCompra);
                cmd.Parameters.AddWithValue("@OC_FechaEmision", dto_oc.OC_FechaEmision);
                cmd.Parameters.AddWithValue("@OC_FechaEntrega", dto_oc.OC_FechaEntrega);
                cmd.Parameters.AddWithValue("@OC_idProveedor", dto_oc.P_idProveedor);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
       
        public bool Consultar_OC(int i)
        {

                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Consultar_OC",conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OC_idOrdenCompra",i));          
                SqlDataReader reader = cmd.ExecuteReader();
                bool hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    //Hay registros
                    dto_oc.OC_idOrdenCompra = (int)reader[0];
                    dto_oc.OC_TipoComprobante = (string)reader[1];
                    dto_oc.OC_NumeroComprobante = (string)reader[2];
                    dto_oc.OC_FormaPago = (string)reader[3];
                    dto_oc.OC_FechaPago = (DateTime)reader[4];
                    dto_oc.OC_TotalCompra = (decimal)reader[5];
                    dto_oc.OC_FechaEmision = (DateTime)reader[6];
                    dto_oc.OC_FechaEntrega = (DateTime)reader[7];
                    dto_oc.P_idProveedor = (int)reader[8];
                    dto_oc.Estado = 100;
                }
                 dto_oc.Estado = 99;
                conexion.Close();
                return hayRegistros;
          

        }

        public void Leer_OCxFecha()
        {
            //conexion.Open();
            //SqlCommand comando = new SqlCommand("SP_Consultar_Listas_OC", conexion);
            //comando.CommandType = CommandType.StoredProcedure;
            //SqlCommand cmd = new SqlCommand("SP_Consulta_OCxFecha", conexion);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@OC_FechaEntrega",))

        }
        public void Actualizar_OC(DTO_OC dto_oc)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualizar_OC", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OC_idOrdenCompra", dto_oc.OC_idOrdenCompra));
                cmd.Parameters.Add(new SqlParameter("@OC_TipoComprobante", dto_oc.OC_TipoComprobante));
                cmd.Parameters.Add(new SqlParameter("@OC_NumeroComprobante", dto_oc.OC_NumeroComprobante));
                cmd.Parameters.Add(new SqlParameter("@OC_FormaPago", dto_oc.OC_FormaPago));
                cmd.Parameters.Add(new SqlParameter("@OC_FechaPago", dto_oc.OC_FechaPago));
                cmd.Parameters.Add(new SqlParameter("@OC_TotalCompra", dto_oc.OC_TotalCompra));
                cmd.Parameters.Add(new SqlParameter("@OC_FechaEntrega", dto_oc.OC_FechaEntrega));
                cmd.Parameters.Add(new SqlParameter("@P_idProveedor", dto_oc.P_idProveedor));

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int EnviarCorreo(DTO_OC dto_oc)
        {
            MailMessage msg = new MailMessage();
            
            if (Consultar_OC(dto_oc.OC_idOrdenCompra))
            {
                
                dto_proveedor.P_idProveedor = dto_oc.P_idProveedor;
                if (dao_proveedor.DAO_Consultar_Proveedor(dto_proveedor))
                {

                    msg.To.Add(dto_proveedor.P_CorreoContacto);
                    msg.Subject = "Orden de Compra" + dto_oc.OC_idOrdenCompra;
                    msg.SubjectEncoding = System.Text.Encoding.UTF8;
                    msg.Body = "Orden Compra:" + dto_oc.P_idProveedor + "\rTipo Comprobante:" + dto_oc.OC_TipoComprobante
                        + "\rNumero Comprobante:" + dto_oc.OC_NumeroComprobante + "\rFecha Emision" + dto_oc.OC_FechaEmision + "\r\r" +
                        "Insumos";
                    msg.BodyEncoding = System.Text.Encoding.UTF8;
                    msg.From = new MailAddress("stephyganz@gmail.com");

                    SmtpClient cliente = new SmtpClient();
                    cliente.Credentials = new NetworkCredential("stephyganz@gmail.com","EnderWiggin612");
                    // Gmail
                    cliente.Host = "smtp.gmail.com";
                    cliente.Port = 587;
                    cliente.EnableSsl = true;
                    

                      cliente.Send(msg);


                    return 1;
                }

            }

            return 2;

        }
        public DTO_OC OC_Actual(int i)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_OC", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@OC_idOrdenCompra", i);
            comando.ExecuteNonQuery();
            DTO_OC oc = new DTO_OC();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                oc.OC_idOrdenCompra = Convert.ToInt32(reader[0]);
                oc.OC_TipoComprobante = reader[1].ToString();
                oc.OC_NumeroComprobante = reader[2].ToString();
                oc.OC_TotalCompra = Convert.ToDecimal(reader[3].ToString());
                oc.OC_FechaEmision = Convert.ToDateTime(reader[4]);
                oc.P_idProveedor = Convert.ToInt32(reader[5]);
            }
            conexion.Close();
            return oc;
        }
        public int ID_OC_Actual()
        {
            int id;
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_OC_Mayor", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            comando.ExecuteNonQuery();
            conexion.Close();
            id = Convert.ToInt32(comando.Parameters["@id"].Value);

            return id;
        }
        public DataTable Leer_OC()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Listas_OC", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            return dt;
        }
        public void Eliminar_OC(DTO_OC dto_oc)
        {

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Eliminar_OC", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OC_idOrdenCompra", dto_oc.OC_idOrdenCompra));
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
