using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAO;

namespace CTR
{
    class CTR_Estado_OC
    {
        DAO_Estado_OC dao_estado_oc;

        public CTR_Estado_OC()
        {
            dao_estado_oc = new DAO_Estado_OC();
        }
        public void CTR_Registrar_Estado_OC(DTO_Estado_OC dto_estado_oc)
        {
            dao_estado_oc.DAO_Registrar_Estado_OC(dto_estado_oc);
        }
    }
}
