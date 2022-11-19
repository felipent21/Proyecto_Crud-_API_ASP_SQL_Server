using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTransito.DTOs
{
    public class MatriculasDTO
    {
        
        //[Key]
        public int Id { get; set; }        
        public string Numero { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public DateTime ValidaHasta { get; set; }
        public bool Activo { get; set; }


    }
}
