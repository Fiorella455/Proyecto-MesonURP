using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAO;
using DTO;

namespace CTR
{
  public  class CTR_Tipo_Documento
    {
        DAO_Tipo_Documento tipo_documento;
        public CTR_Tipo_Documento()
        {
            tipo_documento = new DAO_Tipo_Documento();
        }

        public DTO_Tipo_Documento Consultar_Tipo_Documento_ID(int i)
        {
            return tipo_documento.Consultar_Tipo_Documento_ID(i);
        }
        public DataSet Consultar_Tipos_Documento()
        {
            return tipo_documento.Consultar_Tipos_Documento();
        }
    }
}
