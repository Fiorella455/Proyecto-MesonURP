﻿using System;
using System.Dynamic;

namespace DTO
{
    public class DTO_OC
    {
        public int OC_idOrdenCompra { get; set; }
        public string OC_TipoComprobante { get; set; }
        public string OC_NumeroComprobante { get; set; }       
        public string OC_FormaPago { get; set; }
        public DateTime OC_FechaPago { get; set; }     
        public decimal OC_TotalCompra { get; set; }
        public DateTime OC_FechaEmision { get; set; }
        public DateTime OC_FechaEntrega { get; set; }
        public int P_idProveedor { get; set; }
        public int Estado { get; set; }

        
    }
}

