﻿using System;
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
            cmd.Parameters.AddWithValue("@OC_TipoComprobante", dto_oc.OC_TipoComprobante);
            cmd.Parameters.AddWithValue("@OC_NumeroComprobante", dto_oc.OC_NumeroComprobante);
            cmd.Parameters.AddWithValue("@OC_FormaPago", dto_oc.OC_FormaPago);
            cmd.Parameters.AddWithValue("@OC_TotalCompra", dto_oc.OC_TotalCompra);
            cmd.Parameters.AddWithValue("@OC_FechaEmision", dto_oc.OC_FechaEmision);
            cmd.Parameters.AddWithValue("@P_idProveedor", dto_oc.P_idProveedor);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public bool Consultar_OC(DTO_OC dto_oc)
        {

            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Consultar_OC", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@OC_idOrdenCompra", dto_oc.OC_idOrdenCompra));
            SqlDataReader reader = cmd.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                //Hay registros
                dto_oc.OC_idOrdenCompra = (int)reader[0];
                dto_oc.OC_TipoComprobante = (string)reader[1];
                dto_oc.OC_NumeroComprobante = (string)reader[2];
                dto_oc.OC_FormaPago = (string)reader[3];
                dto_oc.OC_TotalCompra = (decimal)reader[4];
                dto_oc.OC_FechaEmision = (string)reader[5];
                dto_oc.P_idProveedor = (int)reader[6];
                dto_oc.Estado = 100;
            }
            dto_oc.Estado = 99;
            conexion.Close();
            return hayRegistros;
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
                cmd.Parameters.Add(new SqlParameter("@OC_TotalCompra", dto_oc.OC_TotalCompra));
                cmd.Parameters.Add(new SqlParameter("@P_idProveedor", dto_oc.P_idProveedor));

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int EnviarCorreo(DTO_OC dto_oc, string msj)
        {
            try
            {
                if (Consultar_OC(dto_oc))
                {
                    dto_proveedor.P_idProveedor = dto_oc.P_idProveedor;
                    if (dao_proveedor.DAO_Consultar_Proveedor(dto_proveedor))
                    {
                        MailMessage msg = new MailMessage();
                        msg.To.Add(dto_proveedor.P_CorreoContacto);
                        msg.Subject = "Orden de Compra" + dto_oc.OC_idOrdenCompra;
                        msg.SubjectEncoding = Encoding.UTF8;
                        msg.IsBodyHtml = true;
                        msg.Body = msj;
                        msg.BodyEncoding = Encoding.UTF8;
                        msg.From = new MailAddress("mesonurp@gmail.com");
                        SmtpClient cliente = new SmtpClient
                        {
                            Credentials = new NetworkCredential("mesonurp@gmail.com", "meson123456"),
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true
                        };
                        cliente.Send(msg);
                        return 1;
                    }
                }
                return 2;
            }
            catch (Exception)
            {
                throw;
            }
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
                oc.OC_FechaEmision = reader[4].ToString();
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
            conexion.Close();
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
            conexion.Close();
            return dt;
        }
        public DataTable Leer_IxOC(int OC_idOrdenCompra)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Consultar_InsumoxOC", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@OC_idOrdenCompra", OC_idOrdenCompra));
            cmd.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            da1.Fill(dt1);
            conexion.Close();
            return dt1;
        }
        public void Eliminar_OC(int OC_idOrdenCompra)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Eliminar_OC", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OC_idOrdenCompra", OC_idOrdenCompra));
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Leer_OC_Recibido()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Listas_OC_Recibidas", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        //--------------------------------------
        public DataTable Leer_OCxMes(int i)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Listas_OCxMes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mes", i));
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
            sqlData.Fill(dataTable);
            conexion.Close();
            return dataTable;
        }
        public int Count_OCxMes(int i)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Listas_OCxMes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mes", i));
            SqlParameter estado = cmd.Parameters.Add("estado", System.Data.SqlDbType.Int);
            estado.Direction = System.Data.ParameterDirection.ReturnValue;
            Convert.ToInt32(cmd.ExecuteNonQuery());
            dto_oc.Estado = (int)estado.Value;
            conexion.Close();
            return dto_oc.Estado;

        }
        public bool Existe_Numero_Comprobante(long n)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Consultar_Numero_Comprobante", conexion);
            comando.Parameters.AddWithValue(@"OC_NumeroComprobante", n);
            comando.CommandType = CommandType.StoredProcedure;
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

        public long  Generar_Numero_Comprobante(int i)
        {

            Random r = new Random();
            long f = 0;
            if (i == 1)//Factura
            {
                do
                {
                    f = r.Next(100000, 999999);
                } while (Existe_Numero_Comprobante(f));
            }
            else if (i == 2)//Boleta
            {
                int a, b;
                string boleta;
                do
                {
                    a = r.Next(10000, 99999);
                    b = r.Next(9);
                    boleta = a + "" + b;
                    f = long.Parse(boleta);

                } while (Existe_Numero_Comprobante(f));

            }

            return f;

        }    
        public int Increment()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Incrementar", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            int count = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();
            return count;
            
        }
        public bool VericarExisteNC(DTO_OC dto_oc)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Consultar_OC_Repetido", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OC_NumeroComprobante", dto_oc.OC_NumeroComprobante);
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

    }
}
