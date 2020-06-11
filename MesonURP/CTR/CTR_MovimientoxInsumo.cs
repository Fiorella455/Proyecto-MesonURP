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
        public DataTable BuscarUnidad(int idInsumo)
        {
            return objDAO.SelectUnidad(idInsumo);
        }
        public DataSet CargarInsumoEgreso()
        {
            return objDAO.CargarInsumoEgreso();
        }
    }
}
