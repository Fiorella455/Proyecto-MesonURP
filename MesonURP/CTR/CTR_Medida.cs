using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTR
{
    public class CTR_Medida
    {
        DAO_Medida objMed;
        public CTR_Medida()
        {
            objMed = new DAO_Medida();
        }
        public DataSet LeerMedidas()
        {
            return objMed.selectMedidas();
        }
    }
}
