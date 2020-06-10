using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System.Security.Cryptography.X509Certificates;

namespace DAO
{
    public class Dao_Recurso
    {
        SqlConnection conexion;
        DTO_Categoria dto_categoria;
        Dto_Recurso dto_recurso;
        int state=0;
        public Dao_Recurso()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void Dao_Registrar_Recurso(Dto_Recurso dto_rec)
        {
            SqlCommand cmd = new SqlCommand("SP_Agregar_Recurso", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VR_NombreRecurso", dto_rec.VR_NombreRecurso);
            cmd.Parameters.AddWithValue("@DR_FechaIngreso", dto_rec.DR_FechaIngreso);
            cmd.Parameters.AddWithValue("@DR_FechaSalida", dto_rec.DR_FechaSalida);
            cmd.Parameters.AddWithValue("@DR_StockMaximo", dto_rec.DR_StockMaximo);
            cmd.Parameters.AddWithValue("@DR_StockMinimo", dto_rec.DR_StockMinimo);
            cmd.Parameters.AddWithValue("@DR_PrecioUnitario", dto_rec.DR_PrecioUnitario);
            cmd.Parameters.AddWithValue("@DR_CantidadEntrada", dto_rec.DR_CantidadEntrada);
            cmd.Parameters.AddWithValue("@DR_CantidadSalida", dto_rec.DR_CantidadSalida);
            cmd.Parameters.AddWithValue("@DR_CantidadTotal", dto_rec.DR_CantidadTotal);

            cmd.Parameters.AddWithValue("@FK_IC_Categoria", dto_rec.FK_IC_Categoria);
            cmd.Parameters.AddWithValue("@FK_IM_Medida", dto_rec.FK_IM_Medida);
            cmd.Parameters.AddWithValue("@FK_IER_EstadoRecurso", dto_rec.FK_IER_EstadoRecurso);


            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public DataSet Dao_Leer_Insumo(int idCategoria)
        {

            if (dto_recurso.FK_IC_Categoria == idCategoria)
            {
                dto_recurso.FK_IC_Categoria = idCategoria;
            }

                string Select = "SELECT * FROM T_Insumo WHERE C_idCategoria= '" + dto_recurso.FK_IC_Categoria + "'";
                conexion.Open();
                SqlCommand cmd = new SqlCommand(Select, conexion);
                cmd.ExecuteNonQuery();

                DataSet dataset = new DataSet();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(dataset);
                return dataset;
 
        }
        public void CargarInsumoxCategoria()
        {
            /*
             * int catselect= ddlcategoria.SelectedItem.Value;
            CTR_Recurso = new CTR_Recurso();
            dataset = new DataSet();
            dataset = CTR_Recurso.CTR_Leer_RecursoxCategoria(catselect);
            ddlinsumo.DataTextField = "VR_NombreInsumo";
            ddlinsumo.DataValueField = "PK_idInsumo";
            ddlinsumo.DataSource = dataset;
            ddlinsumo.DataBind();
            */
        }
    }
}
