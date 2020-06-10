using System;

namespace DAO
{
    public class ConexionBD
    {
        public static string CadenaConexion
        {
            get
            {
                return "Data Source = IDEA-PC; initial catalog=DB_MesonURP; integrated security=true;";
            }
        }
    }
}
