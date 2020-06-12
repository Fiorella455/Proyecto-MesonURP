using System;

namespace DAO
{
    public class ConexionBD
    {
        public static string CadenaConexion
        {
            get
            {
                return "Data Source = (Local); initial catalog=DB_MesonURP; integrated security=true;";
            }
        }
    }
}
