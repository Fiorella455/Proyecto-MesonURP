using System;

namespace DTO
{
    public class DTO_OC
    {
        public int OC_idOrdenCompra { get; set; }
        public string OC_TipoComprobante { get; set; }
        public string OC_NumeroComprobante { get; set; }
        public double OC_TotalCompra { get; set; }
        public DateTime OC_FechaEmision { get; set; }
        public int P_idProveedor { get; set; }
    }
}

