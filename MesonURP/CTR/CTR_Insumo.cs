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
        public DataSet SelectInsumosOC()
        {
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
        public DataTable consultarInsumo()
        {
            return dao_insumo.consultarInsumoTable();
        }
        public void RegistrarInsumo(DTO_Insumo objIns)
        {
            dao_insumo.registrarInsumo(objIns);
        }
        public void ActualizarInsumo(DTO_Insumo objIns)
        {
            dao_insumo.actualizarInsumo(objIns);
        }
        public DataTable getInsumos(int I_idInsumo)
        {
            return dao_insumo.consultarInsumo1(I_idInsumo);
        }

        //public DataTable consultarInsumo1(int I_idInsumo)
        //{
        //    return objDAO.consultarInsumo1(I_idInsumo);
        //}

        public void eliminarInsumo(DTO_Insumo objIns)
        {
            dao_insumo.eliminarInsumo(objIns);
        }

        public DataTable consultarInsumo2(int I_idInsumo)
        {
            return dao_insumo.consultarInsumo2(I_idInsumo);
        }
        public bool VerificarExisteInsumo(DTO_Insumo objIns)
        {
            return dao_insumo.VericarExisteNombreInsumo(objIns);
        }
        public bool CTR_Consultar_Relacion_InsumoxMxOC(int I_idInsumo)
        {
            return dao_insumo.DAO_Consultar_Relacion_InsumoxMxOC(I_idInsumo);
        }
        public bool CTR_Consultar_Relacion_InsumoxM(int I_idInsumo)
        {
            return dao_insumo.DAO_Consultar_Relacion_InsumoxM(I_idInsumo);
        }
        public bool CTR_Consultar_Relacion_InsumoxOC(int I_idInsumo)
        {
            return dao_insumo.DAO_Consultar_Relacion_InsumoxOC(I_idInsumo);
        }
        public DTO_Insumo Consultar_InsumoxID(int i)
        {
            return dao_insumo.Consultar_InsumoxID(i);
        }
        public int CTR_LimiteStockMax(int id, decimal c)
        {
            return dao_insumo.LimiteStockMax(id, c);
        }
    }
}
