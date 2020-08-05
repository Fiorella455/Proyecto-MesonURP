using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Merma
    {
        public int T_idMerma { get; set; }
        public DateTime M_Fecha { get; set; }
        public decimal M_PesoMerma { get; set; }
        public decimal M_PesoRendimiento { get; set; }
        public string M_Observacion { get; set; }
        public int MxI_idMovimientoxInsumo { get; set; }


    }
}
