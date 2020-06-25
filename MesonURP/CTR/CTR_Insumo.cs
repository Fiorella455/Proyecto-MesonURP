using System;
using DAO;
using DTO;
using System.Data;

namespace CTR
{
    public class CTR_Insumo
    {
        DAO_Insumo dao_insumo;
        public CTR_Insumo()
        {
            dao_insumo = new DAO_Insumo();
        }
        public DataSet Ctr_Leer_Insumo_Categorias(int idCategoria)
        {
           return dao_insumo.Dao_Leer_Insumos_Categorias(idCategoria);
        }
        public DataSet SelectInsumosOC() {
            return dao_insumo.CargarInsumosOC();
        }
        public string SelectPrecioUnitario(int idInsumo)
        {
            return dao_insumo.SelectPrecioUnitario(idInsumo);
        }
        public DataTable ListarInsumo()
        {
            return dao_insumo.SelectInsumo();
        }
        public DataTable BuscarInsumo(string nombreInsumo)
        {
            return dao_insumo.SelectInsumos(nombreInsumo);
        }
        public DataTable ListarDashboard()
        {
            return dao_insumo.SelectDashboard();
        }

    }
}
