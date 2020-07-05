using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
using System.Data;

namespace CTR
{
    public class CTR_Estado_Proveedor
    {
        DAO_Estado_Proveedor dao_estado_proveedor;
        public CTR_Estado_Proveedor() => dao_estado_proveedor = new DAO_Estado_Proveedor();
        public DTO_Estado_Proveedor Consultar_Estado_Proveedor_ID(int i) => dao_estado_proveedor.Consultar_Estado_Proveedor_ID(i);
        public DataSet Consultar_Estados_Proveedor() => dao_estado_proveedor.Consultar_Estados_Proveedor();
    }
}
