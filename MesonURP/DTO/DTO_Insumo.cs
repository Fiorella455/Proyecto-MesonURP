using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
   public class DTO_Insumo
    {
        private string nombreInsumo;
        private int idCategoria;
        private int cantidadTotal;
        private string medida;
        private int estado;

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
        public int CantidadTotal{
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
