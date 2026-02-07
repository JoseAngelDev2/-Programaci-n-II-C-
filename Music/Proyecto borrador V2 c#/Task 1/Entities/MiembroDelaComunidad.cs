using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CURSO_C_.Entities
{
    public abstract class MiembroDelaComunidad
    {
        public int IdMiembroDelaComunidad {get; set;}
        public string Nombre {get; set;}
        public string Correo {get; set;}
    }
}