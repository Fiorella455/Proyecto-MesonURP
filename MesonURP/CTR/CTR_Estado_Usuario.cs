using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
using System.Data;

namespace CTR
{
    public class CTR_Estado_Usuario
    {
        DAO_Estado_Usuario usu;
        public CTR_Estado_Usuario()
        {
            usu = new DAO_Estado_Usuario();
        }
        public Dto_EstadoUsuario Consultar_Estado_Usuario_ID(int i)
        {
            return usu.Consultar_Estado_Usuario_ID(i);
        }
        public DataSet Consultar_Estados_Usuario()
        {
            return usu.Consultar_Estados_Usuario();
        }
    }
}
