using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;

namespace CTR
{
    class CTR_MovimientoxInsumo
    {
        DAO_MovimientoxInsumo dao_movxinsumo;

        public CTR_MovimientoxInsumo()
        {
            dao_movxinsumo = new DAO_MovimientoxInsumo();
        }

        public void Ctr_Registrar_MovxInsumo(DTO_MovimientoxInsumo dto_movxinsumo)
        {
            dao_movxinsumo.Dao_Registrar_MovxInsumo(dto_movxinsumo);    
        }
    }
}
