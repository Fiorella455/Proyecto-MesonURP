using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTR
{
    public class CTR_Categoria
    {
        DAO_Categoria objMov;

        public CTR_Categoria()
        {
            objMov = new DAO_Categoria();
        }
        public DataSet LeerCategorias()
        {
            return objMov.selectCategorias();
        }
    }
}
