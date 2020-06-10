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
        public DataSet CTR_Leer_Categorias()
        {
              return dao_categoria.DAO_Leer_Categorias();
        }

    }
}
