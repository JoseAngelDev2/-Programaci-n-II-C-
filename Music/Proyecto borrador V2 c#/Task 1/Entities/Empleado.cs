using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CURSO_C_.Entities
{
    public class Empleado : MiembroDelaComunidad
    {
        public decimal salario {get; set;}
        public string rol {get; set;}

        public DateTime FechaDeSalida {get; set;}
        public DateTime FechaDeInicio {get; set;}
    }
}