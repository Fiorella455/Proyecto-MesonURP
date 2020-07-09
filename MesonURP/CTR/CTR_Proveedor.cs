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
        public void Registrar_Proveedor(DTO_Proveedor proveedor)
        {
            dao_proveedor.Registrar_Proveedor(proveedor);
        }
        public DataSet Leer_Proveedor()
        {
            return dao_proveedor.DAO_Leer_Proveedor();
        }
        public void Actualizar_Proveedor(DTO_Proveedor proveedor)
        {
            dao_proveedor.Actualizar_Proveedor(proveedor);
        }
        public DTO_Proveedor Consultar_Proveedor(int i)
        { 
           return dao_proveedor.Consultar_Proveedor(i); 
        }
        public void Eliminar_Proveedor(int i)
        {
            dao_proveedor.Eliminar_Proveedor(i);
        }
        public bool Hay_Proveedor(DTO_Proveedor p)
        { 
           return dao_proveedor.Hay_Proveedor(p); 
        }
        public bool Existe_Proveedor_OC(string rs)
        {
            return dao_proveedor.Existe_Proveedor_OC(rs);
        }

        
    }
}

