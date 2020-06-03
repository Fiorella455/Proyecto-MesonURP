using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Categoria
    {
        private int idCategoria;
        private string nombreCategoria;
        private string descripcion;

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
        public DTO_Categoria() {
            idCategoria = 0;
            nombreCategoria = "";
        }
    }
    
}
