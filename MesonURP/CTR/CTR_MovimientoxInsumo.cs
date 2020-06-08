using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTR
{
    public class CTR_MovimientoxInsumo
    {
        DAO_MovimientoxInsumo objMov;

        public CTR_MovimientoxInsumo()
        {
            objMov = new DAO_MovimientoxInsumo();
        }
        public void RegistrarMovimientoxInsumo(DTO_MovimientoxInsumo objDto)
        {
            //Registro de Movimiento, estado = 99
            objMov.RegistarMovimientoxInsumo(objDto);
            objDto.Estado = 99;

            ////Verificacion de Cantidad, error = 3
            //int iCantidad = objDto.Cantidad;
            //bool correcto = iCantidad > 0 && iCantidad < 100;
            //if (!correcto)
            //{
            //    objDto.Estado = 3;
            //    return;
            //}
        }
    }
}
