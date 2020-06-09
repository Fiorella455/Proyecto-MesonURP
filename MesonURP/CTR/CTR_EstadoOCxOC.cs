using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;

namespace CTR
{
    class CTR_EstadoOCxOC
    {
        DAO_EstadoOCxOC dao_estadoOCxOC;

        public CTR_EstadoOCxOC()
        {
            dao_estadoOCxOC = new DAO_EstadoOCxOC();
        }
        public void CTR_Registrar_Proveedor(DAO_EstadoOCxOC dto_estadoOCxOC)
        {

            dao_estadoOCxOC.DAO_Registrar_OC(dto_estadoOCxOC);
        }
    }
}
