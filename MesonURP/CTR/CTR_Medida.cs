using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;
using DTO;

namespace CTR
{
    public class CTR_Medida
    {
        DAO_Medida dao_medida;


        public CTR_Medida()
        {

            dao_medida = new DAO_Medida();
        }
        public string BuscarMedida(int i)
        {
            return dao_medida.SelectMedida(i);

        }
        public DTO_Medida Consultar_MedidaxInsumo(int i)
        {
            return dao_medida.Consultar_MedidaxInsumo(i);
        }
    }
}
