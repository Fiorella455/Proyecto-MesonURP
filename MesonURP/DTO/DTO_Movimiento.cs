using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Movimiento
    {
        private string tipoMovimiento;

        public string TipoMovimiento { 
            get { 
                return tipoMovimiento; 
            } 
            set { 
                tipoMovimiento = value; 
            } 
        }
    }
}
