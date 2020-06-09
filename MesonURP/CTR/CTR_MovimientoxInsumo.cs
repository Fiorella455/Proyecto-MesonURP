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
            //Registro de Movimiento, estado = 99
            objDAO.RegistarMovimientoxInsumo(objDto);
            objDto.Estado = 99;
        }
        public DataTable BuscarUnidad(int idInsumo)
        {
            return objDAO.SelectUnidad(idInsumo);
        }
    }
}
