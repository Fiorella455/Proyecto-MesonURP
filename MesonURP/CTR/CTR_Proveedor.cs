using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAO;
using DTO;

namespace CTR
{
    public class CTR_Proveedor
    {
        DAO_Proveedor dao_proveedor;

        public CTR_Proveedor()
        {
            dao_proveedor = new DAO_Proveedor();
        }
        public void CTR_Registrar_Proveedor(DTO_Proveedor dto_proveedor)
        { 
            
            dao_proveedor.DAO_Registrar_Proveedor(dto_proveedor);
        }
        public DataSet Leer_Proveedor()
        {
            return dao_proveedor.DAO_Leer_Proveedor();
        }
    }
}
