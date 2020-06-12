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
        public void DAO_Registrar_OC(DTO_OC dto_oc)
        {
            
                SqlCommand cmd = new SqlCommand("SP_Insertar_OC", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OC_idOrdenCompra", dto_oc.OC_idOrdenCompra);
                cmd.Parameters.AddWithValue("@OC_TipoComprobante", dto_oc.OC_TipoComprobante);
                cmd.Parameters.AddWithValue("@OC_NumeroComprobante", dto_oc.OC_NumeroComprobante);
                cmd.Parameters.AddWithValue("@OC_TotalCompra", dto_oc.OC_TotalCompra);
                cmd.Parameters.AddWithValue("@OC_FechaEmision", dto_oc.OC_FechaEmision);
                cmd.Parameters.AddWithValue("@OC_idProveedor", dto_oc.P_idProveedor);
           

        }
       
        public bool DAO_Consultar_OC(DTO_OC dto_oc)
        {

                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Consultar_OC",conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OC_idOrdenCompra", dto_oc.OC_idOrdenCompra);
                
                SqlDataReader reader = cmd.ExecuteReader();
                bool hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    //Hay registros
                    dto_oc.OC_idOrdenCompra = (int)reader[0];
                    dto_oc.OC_TipoComprobante = (string)reader[1];
                    dto_oc.OC_NumeroComprobante = (string)reader[2];
                    dto_oc.OC_TotalCompra = (decimal)reader[3];
                    dto_oc.OC_FechaEmision = (DateTime)reader[4];
                     dto_oc.P_idProveedor = (int)reader[5];
                    dto_oc.Estado = 100;
                }
                 dto_oc.Estado = 99;
                conexion.Close();
                return hayRegistros;
          

        }
        public void DAO_Actualizar_OC(DTO_OC dto_oc)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Insertar_OC", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OC_idOrdenCompra", dto_oc.OC_idOrdenCompra));
                cmd.Parameters.Add(new SqlParameter("@OC_TipoComprobante", dto_oc.OC_TipoComprobante));
                cmd.Parameters.Add(new SqlParameter("@OC_NumeroComprobante", dto_oc.OC_NumeroComprobante));
                cmd.Parameters.Add(new SqlParameter("@OC_TotalCompra", dto_oc.OC_TotalCompra));
                cmd.Parameters.Add(new SqlParameter("@OC_FechaEmision", dto_oc.OC_FechaEmision));
                cmd.Parameters.Add(new SqlParameter("@P_idProveedor", dto_oc.P_idProveedor));

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string EnviarCorreo(int iOC)
        {
            MailMessage msg = new MailMessage();
            dto_oc.OC_idOrdenCompra = iOC;
            if (DAO_Consultar_OC(dto_oc))
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

                    
                    return prueba = "Enviado"+" "+dto_proveedor.P_CorreoContacto;
                }

            }

            return prueba = "No enviado";

        }



    }
}
