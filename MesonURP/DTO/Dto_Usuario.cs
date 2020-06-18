using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dto_Usuario
    {
        public int U_idUsuario { get; set; }
        public string U_Nombre { get; set; }
        public string U_APaterno { get; set; }
        public string U_Materno { get; set; }
        public string U_Celular { get; set; }
        public string U_Correo { get; set; }
        public string U_Direccion { get; set; }
        public DateTime U_FechaNacimiento { get; set; }
        public string U_Sexo { get; set; }
        public string U_Contraseña { get; set; }
        public string U_Dni { get; set; }
        public int TU_idTipoUsuario { get; set; }
        public int EU_idEstadoUsuario { get; set; }
        public int TD_idTipoDocumento { get; set; }

    }
}
