using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
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
        public bool getContraseñaU(Dto_Usuario dto_usu)
        {
            return dao_usu.getContraseñaU(dto_usu);
        }

        public void Cambiar_Contraseña(Dto_Usuario dto_usu)
        {
            dao_usu.CambiarContraseña(dto_usu);
        }
        public DataSet Consultar_Usuarios()
        {
            return dao_usu.Consultar_Usuarios();
        }
        public Dto_Usuario Consultar_Usuario_ID(int i)
        {
            return dao_usu.Consultar_Usuario_ID(i);
        }
        public void Registrar_Usuario(Dto_Usuario u)
        {
            dao_usu.Registrar_Usuario(u);
        }
        public void Actualizar_Usuario(Dto_Usuario u)
        {
            dao_usu.Actualizar_Usuario(u);
        }
        public void Eliminar_Usuario(int i)
        {
            dao_usu.Eliminar_Usuario(i);
        }
        public bool Existe_Usuario(Dto_Usuario u)
        {
            return dao_usu.Existe_Usuario(u);
        }
    }
   
}
