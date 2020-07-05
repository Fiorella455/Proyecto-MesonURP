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
        public DataTable RegistrarMovimiento(string TipoMovimiento) {
            
           return objMov.RegistrarMovimiento(TipoMovimiento);
        }
    }
}
