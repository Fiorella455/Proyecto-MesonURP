﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
   public class DTO_Insumo
    {
        private string nombreInsumo;
        private int idInsumo;
        private int idCategoria;
        private decimal cantidadTotal;
        private string medida;
        private decimal stockMax;
        private decimal stockMin;
        private int idEstadoInsumo;
        private decimal precioUnitario;
        private DateTime fechaVencimiento;
        public string NombreInsumo {
            get
            { 
                return nombreInsumo; 
            }
            set
            {
                nombreInsumo = value;
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

        public int Idcategoria {
            get
            {
                return idCategoria;
            }
            set
            {
                idCategoria = value;
            }
        }
        public decimal CantidadTotal
        {
            get
            {
                return cantidadTotal;
            }
            set
            {
                cantidadTotal = value;
            }
        }
        public string Medida{
            get
            {
                return medida;
            }
            set
            {
                medida = value;
            }
        }
        public decimal StockMax
        {
            get
            {
                return stockMax;
            }
            set
            {
                stockMax = value;
            }
        }
        public decimal StockMin
        {
            get
            {
                return stockMin;
            }
            set
            {
                stockMin = value;
            }
        }
        public int IdEstadoInsumo
        {
            get
            {
                return idEstadoInsumo;
            }
            set
            {
                idEstadoInsumo = value;
            }
        }
        public decimal PrecioUnitario
        {
            get
            {
                return precioUnitario;
            }
            set
            {
                precioUnitario = value;
            }
        }
        public DateTime FechaVencimiento
        {
            get
            {
                return fechaVencimiento;
            }
            set
            {
                fechaVencimiento = value;
            }
        }
      
    }
}