using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;
using DTO;

namespace CTR
{
    public class CTR_Merma
    {
        DAO_Merma dao_Merma;
        public CTR_Merma()
        {
            dao_Merma = new DAO_Merma();
        }
        public DataTable ConsultarMermas()
        {
            return dao_Merma.consultaMerma();
        }
        public DataTable BusquedaInsumoMerma(string I_NombreInsumo)
        {
            return dao_Merma.BuscarInsumoMerma(I_NombreInsumo);
        }
        public DataSet ListarInsumos(DateTime Fecha)
        {
            return dao_Merma.selectInsumosEgresados(Fecha);
        }
        public string MostrarEgreseos(int idInsumo, DateTime Fecha)
        {
            return dao_Merma.mostrarEgresos(idInsumo, Fecha);
        }
        public string SumarEgreseos(int idInsumo, DateTime Fecha)
        {
            return dao_Merma.sumarEgresos(idInsumo, Fecha);
        }
        public string Rendimiento(int idInsumo, decimal pesoMerma)
        {
            return dao_Merma.PesoRendimiento(idInsumo, pesoMerma);
        }
        public void agregarMerma(DTO_Merma objMerma)
        {
             dao_Merma.AgregarMerma(objMerma);
        }
        public void actualizarMerma(DTO_Merma objMerma)
        {
            dao_Merma.ActualizarMerma(objMerma);
        }
        public string selectIdMovxIns(int idInsumo)
        {
            return dao_Merma.SelectMovXIn(idInsumo);
        }
        public void EliminarMerma(DTO_Merma objMerma)
        {
            dao_Merma.EliminarMerma(objMerma);    
        }
        public DTO_Merma ConsultarMermaxId(int i)
        {
            return dao_Merma.Consultar_Merma(i);
        }
        public int IdInsumo (DTO_Insumo dto_insumo)
        {
            return  dao_Merma.IdInsumo(dto_insumo);
        }
        public string MostrarMedida(int i)
        {
            return dao_Merma.MostrarMedida(i);
        }

    }
   
}
