using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTR
{
    public class CTR_MovimientoxInsumo
    {
        DAO_MovimientoxInsumo objDAO;

        public CTR_MovimientoxInsumo()
        {
            objDAO = new DAO_MovimientoxInsumo();
        }
        public void RegistrarMovimientoxInsumo(DTO_MovimientoxInsumo objDto)
        {
            objDAO.RegistarMovimientoxInsumo(objDto);
        }
         //public string BuscarUnidad(int IdInsumo)
         //{
         //   return objDAO.SelectMedida(IdInsumo);
         //}
        public DataSet CargarInsumoEgreso()
        {
            return objDAO.CargarInsumoEgreso();
        }
        public DataSet CargarInsumoIngreso()
        {
            return objDAO.CargarInsumoIngreso();
        }
        public void UpdateStockIngreso(DTO_MovimientoxInsumo objDto)
        {
            objDAO.ActualizarStockIngreso(objDto);
        }
        public void UpdateStockEgreso(DTO_MovimientoxInsumo objDto)
        {
            objDAO.ActualizarStockEgreso(objDto);
        }
        public string VerificarStockMin(int IdInsumo)
        {
            return objDAO.StockMin(IdInsumo);
        }
        public string VerificarStockMax(int IdInsumo)
        {
             return objDAO.StockMax(IdInsumo);
        }
        public DataTable BuscarMovimientos(string busquedamov)
        {
            return objDAO.BuscarMovimientos(busquedamov);
        }
        public int ObteneridInsumo(string insumo)
        {
            return objDAO.getInsumo(insumo);
                
        
        }
    }
}
