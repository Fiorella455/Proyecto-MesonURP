using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;

namespace CTR
{
    public class CTR_Categoria
    {
        Dao_Categoria dao_categoria;
        public List<Dao_Categoria>CTR_Leer_Categorias()
        {
             dao_categoria.DAO_Seleccionar_Categoria(dto_categoria);
        }

    }
}
