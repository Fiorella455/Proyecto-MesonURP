using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DTO;
using DAO;

namespace CTR
{
   public class Ctr_TipoUsuario
    {
        Dao_TipoUsuario usu;
        public Ctr_TipoUsuario()
        {
            usu = new Dao_TipoUsuario();
        }
        public Dto_TipoUsuario Consultar_Tipo_Usuario_ID(int i)
        {
            return usu.Consultar_Tipo_Usuario_ID(i);
        }
        public DataSet Consultar_Tipos_Usuario()
        {
            return usu.Consultar_Tipos_Usuario();
        }
    }
}
 