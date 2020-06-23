using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_MovimientoxInsumo
    {
        public int MxI_idMovimientoxInsumo { get; set; }
        public decimal MxI_Cantidad { get; set; }
        public DateTime MxI_FechaMovimiento { get; set; }
        public int I_idInsumo { get; set; }
        public int M_idMovimiento {get;set;}
        public int U_idUsuario{ get; set; }

    }
}
