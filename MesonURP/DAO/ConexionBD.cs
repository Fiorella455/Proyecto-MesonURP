using System;

namespace DAO
{
    public class ConexionBD
    {
        public static string CadenaConexion
        {
            get
            {
                //return "data source=DESKTOP-928V5LN\\SQLEXPRESS; initial catalog=DB_MesonURP; integrated security=SSPI;";
                return "Data Source= DESKTOP-LLEV629;database=DB_MesonURP;integrated security=SSPI;";
            }
        }
    }
}
