using System;
using DAO;
using DTO;

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
    }
}
