using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Movimiento
    {
        private int idRecurso;
        private string tipoMovimiento;
        private DateTime fechaMovimiento;
        private string usuarioMovimiento;

        public DTO_Movimiento(string tipoMovimiento, DateTime fechaMovimiento, string usuarioMovimiento)
        {
            this.TipoMovimiento = tipoMovimiento;
            this.FechaMovimiento = fechaMovimiento;
            this.UsuarioMovimiento = usuarioMovimiento;
        }

        public int IdRecurso {
            get
            { 
                return idRecurso; 
            }

            set { 
                idRecurso = value; 
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
            
        public DTO_Movimiento() {
            tipoMovimiento = "";
            //fechaMovimiento = DateTime.Now;
            usuarioMovimiento = "";
        }
    }
}
