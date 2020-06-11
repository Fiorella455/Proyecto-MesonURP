using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTR
{
    public class CTR_Movimiento
    {
        DAO_Movimiento objMov;

        public CTR_Movimiento()
        {
            objMov = new DAO_Movimiento();
        }
        public void RegistrarMovimiento(DTO_Movimiento objDto) {
            
            //Registro de Movimiento, estado = 99
            objMov.RegistrarMovimiento(objDto);
            objDto.Estado = 99;

        }
        public DataSet CargarInsumoEgreso()
        {
            return objMov.CargarInsumoEgreso();
        }
    }
}
