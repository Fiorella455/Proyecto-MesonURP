using System;

namespace DAO
{
    public class ConexionBD
    {
        public static string CadenaConexion
        {
            get
            {
                //MILAGROS
                //return "data source=DESKTOP-928V5LN\\SQLEXPRESS; initial catalog=DB_MesonURP; integrated security=SSPI;";

                //GRECIA
                //return "Data Source= DESKTOP-LLEV629;database=DB_MesonURP;integrated security=SSPI;";

                //KATYA
                return "data source=LAPTOP-VNIPF8CA; initial catalog=DB_MesonURP; integrated security=SSPI;";
            }
        }
    }
}
