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
        public int ID_MAX()
        {
            return objDAO.ID_Movimiento_Max();
        }
        public DataTable SelectMovimientosxInsumo()
        {
            return objDAO.ConsultarMovimientoxInsumo();
        }
        public DataTable BusquedaMovimientoxInsumo(string busqueda)
        {
            return objDAO.BuscarMovimientoxInsumo(busqueda);
        }
        public DataTable BusquedaMovimientoxInsumoTipo(int tipo)
        {
            return objDAO.BuscarMovimientoxInsumoTipo(tipo);
        }
    }
}
