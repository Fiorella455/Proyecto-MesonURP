using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dto_Categoria
    {
        int idcategoria;
        string nomCategoria;
        string descripcion;
        public Dto_Categoria() : this(0, "", "") { }
        public Dto_Categoria(int icategoria, string nomcategoria, string descripcion)
        {
            this.idCategoria = icategoria;
            this.NombreCategoria = nomcategoria;
            this.Descripcion = descripcion;
        }

        public int idCategoria { get => idcategoria; set => idcategoria = value; }
        public string NombreCategoria { get => nomCategoria; set => nomCategoria = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
