using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
   public class RecursoDTO
    {
        private string nombreRecurso;
        private int idCategoria;
        private int cantidadTotal;
        private string Medida;
        private int Estado;

        public RecursoDTO(string nombrerecurso, int cantidadtotal, string medida, int idcategoria)
        {
            nombreRecurso = nombrerecurso;
            cantidadTotal = cantidadtotal;
            Medida = medida;
            idCategoria = idcategoria;
        }

        public string NombreRecurso {
            get
            { 
                return nombreRecurso; 
            }
            set
            {
                nombreRecurso = value;
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
    }
}
