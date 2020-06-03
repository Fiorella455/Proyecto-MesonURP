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
        private string Medida;

        public DTO_Insumo(string nombreinsumo, int cantidadtotal, string medida, int idcategoria)
        {
            nombreInsumo = nombreinsumo;
            cantidadTotal = cantidadtotal;
            Medida = medida;
            idCategoria = idcategoria;
        }

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
        public int idcategoria {
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
        public string medida{
            get
            {
                return Medida;
            }
            set
            {
                Medida = value;
            }
        }
    }
}
