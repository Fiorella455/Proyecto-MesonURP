using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
    class CategoriaDTO
    {
        private int idCategoria;
        private string nombreCategoria;
        private string descripcion;
        private int Estado;

        public int IdCategoria {
            get { return idCategoria; } set { idCategoria = value; }
        }
        public string NombreCategoria {
            get { 
                return nombreCategoria; 
            }
            set { 
                nombreCategoria = value; 
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
        public CategoriaDTO() {
            idCategoria = 0;
            nombreCategoria = "";
        }
    }
    
}
