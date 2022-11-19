using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTransito.DTOs
{
    public class ConductoresDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public bool Activo { get; set; }

        public int MatriculasId { get; set; }

        public DateTime  Vencimiento  {get; set;}

    }
}
