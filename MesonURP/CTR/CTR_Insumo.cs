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
        public void Ctr_Registrar_Recurso(DTO_Insumo dto_Recurso)
        {
            dao_insumo.Dao_Registrar_Recurso(dto_Recurso);
        }
        public DataSet Ctr_Leer_Insumo_Categorias(int idCategoria)
        {
           return dao_insumo.Dao_Leer_Insumos_Categorias(idCategoria);
        }
        public void Consultar_InsumoxID()
        {
            dao_insumo.Consultar_InsumoxID();
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
