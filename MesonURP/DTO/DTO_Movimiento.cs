﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Movimiento
    {
        private string tipoMovimiento;
        private DateTime fechaMovimiento;
        private string usuarioMovimiento;
        private int estado;


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

        public int Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }
    }
}
