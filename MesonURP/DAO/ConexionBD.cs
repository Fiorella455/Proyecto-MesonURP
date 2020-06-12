using System;

namespace DAO
{
    public class ConexionBD
    {
        public static string CadenaConexion
        {
            get
            {
                return "data source=DESKTOP-7A9J3UP\\MSSQLSERVER01; initial catalog=DB_MesonURP; integrated security=SSPI;";
            }
        }
    }
}
