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
        CTR_Insumo ctr_i;
        public CTR_OCxInsumo()
        {
            dao_ocxinsumo = new DAO_OCxInsumo();
            ctr_i = new CTR_Insumo();
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
        public void CTR_Eliminar_InsumoxOC(int iOC, int idIns)
        {
            dao_ocxinsumo.Eliminar_InsumoxOC(iOC,idIns);
        }

        public int CTR_Verificar_Cantidad(DTO_OCxInsumo dto_ocxi)
        {
            bool max = ctr_i.CTR_LimiteStockMax(dto_ocxi);

            if (max)
            {
                return dto_ocxi.Estado = 110;
                
            }
            if (dto_ocxi.OCxI_Cantidad == 0)
            {
                return dto_ocxi.Estado = 120;
                
            }
            if (dto_ocxi.InsumoR)
            {
                return dto_ocxi.Estado = 130;
               
            }

            // Cantidad Correcta

            return dto_ocxi.Estado = 100;
        }
    }
}

