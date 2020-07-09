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
        DAO_Categoria dao_categoria;

        public CTR_Categoria()
        {
            dao_categoria = new DAO_Categoria();
        }
        public DataSet CTR_Leer_Categorias()
        {
              return dao_categoria.DAO_Leer_Categorias();
        }
        public DataTable CTR_InsumosxCategoria(int C_idCategoria)
        {
            return dao_categoria.DAO_InsumosxCategoria(C_idCategoria);
        }
        public void CTR_AgregarCategoria(DTO_Categoria objCat)
        {
            dao_categoria.DAO_AgregarCategoria(objCat);
        }
        public bool CTR_ExisteCategoria(DTO_Categoria objCat)
        {
            return dao_categoria.DAO_ExisteNombreCategoria(objCat);
        }
        public bool CTR_ExisteInsumoxCategoria(int C_idCategoria)
        {
            return dao_categoria.DAO_ExisteInsumoxCategoria(C_idCategoria);
        }
        public void CTR_EliminarCategoria(DTO_Categoria objCat)
        {
            dao_categoria.DAO_EliminarCategoria(objCat);
        }
        public DataTable CTR_getCategoria(int C_idCategoria)
        {
            return dao_categoria.DAO_ConsultarCategoriaxID(C_idCategoria);
        }
        public void CTR_ActualizarCategoria(DTO_Categoria objCat)
        {
            dao_categoria.DAO_ActualizarCategoria(objCat);
        }
    }
}
