using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_MovimientoxInsumo
    {  
        private int idInsumo;
        private int idMovimiento;
        private DateTime fechaMovimiento;
        private int cantidad;
        private int estado;

        public int IdInsumo
        {
            get
            {
                return idInsumo;
            }

            set
            {
                idInsumo = value;
            }
        }
        public int IdMovimiento { 
            get
            {
                return idMovimiento;
            }
            set
            {
                idMovimiento = value;
            }
        }

        public int Estado {
            get
            {
                return estado;
            }
            set 
            { 
                estado = value; 
            }
        }
        public int Cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                cantidad = value;
            }
        }

        public DateTime FechaMovimiento
        {
            get
            {
                return fechaMovimiento;
            }
            set
            {
                fechaMovimiento = value;
            }
        }
    }
}
