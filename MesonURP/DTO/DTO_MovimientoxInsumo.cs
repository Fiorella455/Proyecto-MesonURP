using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_MovimientoxInsumo
    {  
        private int idInsumo;
        private int idMovimiento;
        private string usuarioMovimiento;
        private DateTime fechaMovimiento;
        private decimal cantidad;

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
        public decimal Cantidad
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
        public string UsuarioMovimiento
        {
            get
            {
                return usuarioMovimiento;
            }
            set
            {
                usuarioMovimiento = value;
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
