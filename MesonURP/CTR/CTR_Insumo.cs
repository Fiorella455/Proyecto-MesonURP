﻿using System;
using DAO;
using DTO;
using System.Data;

namespace CTR
{
    public class CTR_Insumo
    {
        DAO_Insumo dao_insumo;
        public CTR_Insumo()
        {
            dao_insumo = new DAO_Insumo();
        }
        public void Ctr_Registrar_Recurso(DTO_Insumo dto_Recurso)
        {
            dao_insumo.Dao_Registrar_Recurso(dto_Recurso);
        }
        public DataSet Ctr_Leer_Insumo_Categorias(int idCategoria)
        {
           return dao_insumo.Dao_Leer_Insumos_Categorias(idCategoria);
        }
        public DTO_Insumo Consultar_InsumoxID(int i)
        {
             return dao_insumo.Consultar_InsumoxID(i);
        }

        
    }
}
