using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_MovimientoxInsumo
    {
        private int idMovxInsumo;
        private int idInsumo;
        private int idMovimiento;
        private int idusuarioMovimiento;
        private DateTime fechaMovimiento;
        private decimal cantidad;

        public int IdMovxInsumo
        {
            get
            {
                return idMovxInsumo;
            }

            set
            {
                idMovxInsumo = value;
            }
        }
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
        public int IdUsuarioMovimiento
        {
            get
            {
                return idusuarioMovimiento;
            }
            set
            {
                idusuarioMovimiento = value;
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
