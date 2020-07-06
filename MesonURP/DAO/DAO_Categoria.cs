using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System;

namespace DAO
{
    public class Dao_Categoria
    {
         SqlConnection conexion;

        public Dao_Categoria()
        {

            conexion = new SqlConnection(ConexionBD.CadenaConexion); 

        }
        public DataSet selectCategorias()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Select_Categoria", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        //public void DAO_Registrar_Categoria(DTO_Categoria dto_categoria)
        //{
            
        //        SqlCommand cmd = new SqlCommand("SP_Insertar_Categoria", conexion);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@C_idCategoria", dto_categoria.C_idCategoria);
        //        cmd.Parameters.AddWithValue("@C_NombreCategoria", dto_categoria.C_NombreCategoria);
        //        cmd.Parameters.AddWithValue("@C_Descripcion", dto_categoria.C_Descripcion);
      
        //}
        public void DAO_AgregarCategoria(DTO_Categoria objCat)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Agregar_Categoria", conexion as SqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@C_NombreCategoria", objCat.C_NombreCategoria));
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet DAO_Leer_Categorias()
        {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Consultar_Categoria", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
               
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                data.Fill(dataset);
                conexion.Close();
                return dataset;
        }

        public DataTable DAO_InsumosxCategoria(int C_idCategoria)
        {
            try
            {
                conexion.Open();
                SqlDataAdapter _Data = new SqlDataAdapter("SP_Consultar_InsumosxCategoria", conexion);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@C_idCategoria", C_idCategoria);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAO_ExisteNombreCategoria(DTO_Categoria objCat)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Verificar_Nombre_Categoria", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@C_NombreCategoria", objCat.C_NombreCategoria);
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
        public bool DAO_ExisteInsumoxCategoria(int C_idCategoria)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Consultar_Existencia_InsumoxCategoria", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@C_IdCategoria", C_idCategoria);
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
        //public DataTable DAO_ConsultarCategoria(string C_NombreCategoria)
        //{
        //    try
        //    {
        //        SqlDataAdapter _Data = new SqlDataAdapter("SP_Consultar_Categoria1", conexion);
        //        _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        _Data.SelectCommand.Parameters.AddWithValue("@C_NombreCategoria", C_NombreCategoria);
        //        DataSet _Ds = new DataSet();
        //        _Data.Fill(_Ds);
        //        return _Ds.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public void DAO_EliminarCategoria(DTO_Categoria objCat)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Delete_Categoria", conexion as SqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@C_idCategoria", SqlDbType.Int).Value = objCat.C_idCategoria;
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DAO_ConsultarCategoriaxID(int C_idCategoria)
        {
            try
            {
                conexion.Open();
                SqlDataAdapter _Data = new SqlDataAdapter("SP_Consultar_CategoriaxID", conexion);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@C_idCategoria", C_idCategoria);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DAO_ActualizarCategoria(DTO_Categoria objCat)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualizar_Categoria", conexion as SqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@C_idCategoria", objCat.C_idCategoria));
                cmd.Parameters.Add(new SqlParameter("@C_NombreCategoria", objCat.C_NombreCategoria));
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
