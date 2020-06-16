using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;

namespace CTR
{
    public class Ctr_Usuario
    {
        Dao_Usuario dao_usu = new Dao_Usuario();
        public bool validarUsuario(Dto_Usuario dto_usu)
        {
            return dao_usu.Login(dto_usu);
        }
        public void getPerfil(Dto_Usuario dto_usu, Dto_TipoUsuario dto_tus)
        {
            dao_usu.getPerfil(dto_usu, dto_tus);
        }
        public void getUsuario(Dto_Usuario dto_usu)
        {
            dao_usu.getUsuario(dto_usu);
        }
        public void getNomApellUsuario(Dto_Usuario dto_usu)
        {
            dao_usu.getNomApellUsuario(dto_usu);
        }

    }
   
}
