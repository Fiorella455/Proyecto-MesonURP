using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;

namespace CTR
{
    public class CTR_Insumo
    {
        DAO_Insumo objInsumoDao;
        public CTR_Insumo() {
            objInsumoDao = new DAO_Insumo();
        }
        public DataTable ListarInsumo() {
            return objInsumoDao.SelectInsumo();
        }
        public DataTable BuscarInsumo(string nombreInsumo)
        {
            return objInsumoDao.SelectInsumos(nombreInsumo);
        }
    }
}
