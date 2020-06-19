using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;
using DTO;

namespace CTR
{
    public class CTR_Categoria
    {
        Dao_Categoria dao_categoria;

        public CTR_Categoria()
        {
            dao_categoria = new Dao_Categoria();
        }
        public DataSet CTR_Leer_Categorias()
        {
              return dao_categoria.DAO_Leer_Categorias();
        }
        public DataSet LeerCategorias()
        {
            return dao_categoria.SelectCategorias();
        }
    }
}
