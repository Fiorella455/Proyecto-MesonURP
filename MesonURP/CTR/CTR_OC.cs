using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
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
        public void Registrar_OC(DTO_OC dto_oc)
        {

            dao_oc.Registrar_OC(dto_oc);
        }
        public bool CTR_Leer_OC(DTO_OC dto_oc)
        {
            return dao_oc.Consultar_OC(dto_oc);
        }
        public void Actualizar_OC(DTO_OC oc)
        {
            dao_oc.Actualizar_OC(oc);
        }
        public DataTable Leer_OC()
        {
            return dao_oc.Leer_OC();
        }
        //
        //public DataTable Leer_IxOC(int OC_idOrdenCompra)
        //{
        //    return dao_oc.Leer_IxOC(OC_idOrdenCompra);
        //}
        //
        public int ID_OC_Actual()
        {
            return dao_oc.ID_OC_Actual();
        }
        //public DTO_OC OC_Actual(int i)
        //{
        //    return dao_oc.OC_Actual(i);
        //}
        public void Eliminar_OC(int OC_idOrdenCompra)
        {
            dao_oc.Eliminar_OC(OC_idOrdenCompra);
        }

        public int  Enviar_OC(DTO_OC dto_oc, string msj)
        {
           return dao_oc.EnviarCorreo(dto_oc, msj);
        }

        public DataTable Leer_OC_Recibido()
        {
            return dao_oc.Leer_OC_Recibido();
        }
        public DataTable Leer_OCxMes(int i)
        {
            return dao_oc.Leer_OCxMes(i);
        }

        public int Consult_Incremento()
        {
            return dao_oc.Increment();
        }
        public bool VerificarExisteNC(DTO_OC dto_oc)
        {
            return dao_oc.VericarExisteNC(dto_oc);
        }
        public long Generar_Numero_Comprobante(int i)
        {
            return dao_oc.Generar_Numero_Comprobante(i);
        }

    }
   }

