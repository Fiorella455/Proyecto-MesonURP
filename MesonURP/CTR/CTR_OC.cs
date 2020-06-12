using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;

namespace CTR
{
     public class CTR_OC
    {

        DAO_OC dao_oc;

        public CTR_OC()
        {
            dao_oc = new DAO_OC();
        }
        public void CTR_Registrar_OC(DTO_OC dto_oc)
        {

            dao_oc.DAO_Registrar_OC(dto_oc);
        }
        public bool CTR_Leer_OC(DTO_OC dto_oc)
        {
            return dao_oc.DAO_Consultar_OC(dto_oc);
        }
    }
}
