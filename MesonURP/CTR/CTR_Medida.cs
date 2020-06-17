using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;

namespace CTR
{
    public class CTR_Medida
    {
        DAO_Medida dao_medida;


        public CTR_Medida()
        {

            dao_medida = new DAO_Medida();
        }
        public DataSet Leer_Medida()
        {
            return dao_medida.Leer_Medida();

        }
    }
}
