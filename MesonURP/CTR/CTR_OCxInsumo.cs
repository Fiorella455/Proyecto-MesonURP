using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAO;
using DTO;
using System.Security.Cryptography;

namespace CTR
{
    public class CTR_OCxInsumo
    {
        DAO_OCxInsumo dao_ocxinsumo;
        public CTR_OCxInsumo()
        {
            dao_ocxinsumo = new DAO_OCxInsumo();
        }
        public void Registrar_OC_Insumo(DTO_OCxInsumo oc)
        {
            dao_ocxinsumo.Registrar_OCxInsumo(oc);
        }
        public DataTable Leer_InsumoxOC(int i)
        {
            return dao_ocxinsumo.Leer_Insumos_xOC(i);
        }
        public DataTable Leer_InsumoxMes(int m)
        {
            return dao_ocxinsumo.Leer_InsumosxMes(m);
        }
        public void Actualizar_OCxInsumo(DTO_OCxInsumo oc)
        {
            dao_ocxinsumo.Actualizar_OCxInsumo(oc);
        }
        public void Eliminar_OCxInsumo(int i)
        {
            dao_ocxinsumo.Eliminar_Insumos_xOC(i);
        }
    }
}

