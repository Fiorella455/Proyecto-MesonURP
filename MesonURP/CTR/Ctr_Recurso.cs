using System;
using DAO;
using DTO;
using System.Data;

namespace CTR
{
    public class Ctr_Recurso
    {
        Dao_Recurso dao_rec;
        public Ctr_Recurso()
        {
            dao_rec = new Dao_Recurso();
        }
        public void Ctr_Registrar_Recurso(Dto_Recurso dto_Recurso)
        {
            dao_rec.Dao_Registrar_Recurso(dto_Recurso);
        }
        public DataSet Ctr_Leer_RecursoxCategoria(int idCategoria)
        {
           return dao_rec.Dao_Leer_Insumo(idCategoria);
        }
    }
}
