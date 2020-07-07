using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTR
{
    public class CTR_EstadoInsumo
    {
        DAO_EstadoInsumo objEstI;
        public CTR_EstadoInsumo()
        {
            objEstI = new DAO_EstadoInsumo();
        }
        public DataSet LeerEstadoI()
        {
            return objEstI.selectEstadosI();
        }
    }
}
