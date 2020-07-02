using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;
using DTO;

namespace CTR
{
    public class CTR_Insumo
    {
        DAO_Insumo objDAO;
        public CTR_Insumo() 
        {
            objDAO = new DAO_Insumo();
        }
        public DataTable ListarInsumo() 
        {
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
        //-------------------
        public DataTable consultarInsumo()
        {
            return objDAO.consultarInsumoTable();
        }
        public void RegistrarInsumo(DTO_Insumo objIns)
        {
            objDAO.registrarInsumo(objIns);
        }
        public void ActualizarInsumo(DTO_Insumo objIns)
        {
            objDAO.actualizarInsumo(objIns);
        }
        public DataTable getInsumos(int I_idInsumo)
        {
            return objDAO.consultarInsumo1(I_idInsumo);
        }

        public DataTable consultarInsumo1(int I_idInsumo)
        {
            return objDAO.consultarInsumo1(I_idInsumo);
        }

        public void eliminarInsumo(int I_idInsumo)
        {
            objDAO.eliminarInsumo(I_idInsumo);
        }

        public DataTable consultarInsumo2(int I_idInsumo)
        {
            return objDAO.consultarInsumo2(I_idInsumo);
        }
        public bool VerificarExisteInsumo(DTO_Insumo objIns)
        {
            return objDAO.VericarExisteNombreInsumo(objIns);
        }
    }
}
