using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
    public class MovimientoDTO
    {
        private int idMovimiento;
        private string tipoMovimiento;
        private DateTime fechaMovimiento;
        private string usuarioMovimiento;
        private int Estado;

        public MovimientoDTO(string tipoMovimiento, DateTime fechaMovimiento, string usuarioMovimiento)
        {
            this.TipoMovimiento = tipoMovimiento;
            this.FechaMovimiento = fechaMovimiento;
            this.UsuarioMovimiento = usuarioMovimiento;
        }

        public int IdMovimiento {
            get
            { 
                return idMovimiento; 
            }

            set { 
                idMovimiento = value; 
            } 
        }
        public string TipoMovimiento { 
            get { 
                return tipoMovimiento; 
            } 
            set { 
                tipoMovimiento = value; 
            } 
        }
        public DateTime FechaMovimiento { 
            get 
            { 
                return fechaMovimiento; 
            } 
            set { 
                fechaMovimiento = value;
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
            public int estado
        {
            get
            {
                return Estado;
            }
            set
            {
               Estado = value;
            }
        }
        public MovimientoDTO() {
            tipoMovimiento = "";
            //fechaMovimiento = DateTime.Now;
            usuarioMovimiento = "";
        }
    }
}
