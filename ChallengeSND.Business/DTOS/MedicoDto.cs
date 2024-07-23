using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSND.Business.DTOS
{
    public class MedicoDto
    {
     
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public string Apellido { get; set; } = string.Empty;
            public DateTime FechaNacimiento { get; set; } = DateTime.Now;
            public string Especialidad { get; set; } = string.Empty;
            public bool ConTurnosDisponibles { get; set; } = false;
        
    }
}