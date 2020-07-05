using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;

namespace CTR
{
    public class CTR_EstadoOCxOC
    {
        DAO_EstadoOCxOC dao_estadoOCxOC;

        public CTR_EstadoOCxOC()
        {
            dao_estadoOCxOC = new DAO_EstadoOCxOC();
        }
        public void Registrar_Estado_OCxOC(DTO_Estado_OCxOC dto_estado_ocxoc)
        {
            dao_estadoOCxOC.Registrar_Estado_OCxOC(dto_estado_ocxoc);
        }
        public void Consultar_Estado_OCxOC(DTO_Estado_OCxOC dto_estado_ocxoc)
        {
            dao_estadoOCxOC.Registrar_Estado_OCxOC(dto_estado_ocxoc);
        }
        public void Actualizar_Estado_OCxOC(DTO_Estado_OCxOC dto_estado_ocxoc)
        {
            dao_estadoOCxOC.Actualizar_Estado_OCxOC(dto_estado_ocxoc);
        }
    }
}
