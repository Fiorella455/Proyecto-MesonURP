using System;

namespace DTO
{
    public class DTO_OCxInsumo
    {
        
        public int I_idInsumo { get; set; }
        public int OC_idOrdenCompra { get; set; }
        public decimal OCxI_Cantidad { get; set; }
        public decimal OCxI_PrecioTotal { get; set; }
        public int Estado { get; set; }
        public bool InsumoR { get; set; }
    }
}