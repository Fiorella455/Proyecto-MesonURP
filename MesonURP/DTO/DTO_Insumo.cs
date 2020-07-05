using System;
using System.Collections.Generic;
using System.Text;


namespace DTO
{
    public class DTO_Insumo
    {
        public int PK_IR_Recurso { get; set; }
        public string VR_NombreRecurso { get; set; }
        public DateTime DR_FechaIngreso { get; set; }
        public DateTime DR_FechaSalida { get; set; }
        public decimal DR_StockMaximo { get; set; }
        public decimal DR_StockMinimo { get; set; }
        public decimal DR_PrecioUnitario { get; set; }
        public decimal DR_CantidadEntrada { get; set; }
        public decimal DR_CantidadSalida { get; set; }

        public decimal DR_CantidadTotal { get; set; }
        public int FK_IC_Categoria { get; set; }
        public int FK_IM_Medida { get; set; }
        public int FK_IER_EstadoRecurso { get; set; }
    }
}

