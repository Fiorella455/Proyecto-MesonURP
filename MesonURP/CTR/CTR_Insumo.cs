using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;

namespace CTR
{
    public class CTR_Insumo
    {
        DAO_Insumo objDAO;
        public CTR_Insumo() {
            objDAO = new DAO_Insumo();
        }
        public DataTable ListarInsumo() {
            return objDAO.SelectInsumo();
        }
        public DataTable BuscarInsumo(string nombreInsumo)
        {
            return objDAO.SelectInsumos(nombreInsumo);
        }
        public DataTable ListarDashboard()
        {
            return objDAO.SelectDashboard();
        }
        public void Ctr_Registrar_Recurso(DTO_Insumo dto_Recurso)
        {
            objDAO.Dao_Registrar_Recurso(dto_Recurso);
        }
        public DataSet Ctr_Leer_Insumo_Categorias(int idCategoria)
        {
            return objDAO.Dao_Leer_Insumos_Categorias(idCategoria);
        }
        public DTO_Insumo Consultar_InsumoxID(int i)
        {
            return objDAO.Consultar_InsumoxID(i);
        }
    }
}
