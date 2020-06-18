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
    }
}
