using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTransito.DAL.Entities
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Sanciones
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaActual { get; set; }
        public string Sancion { get; set; }
        public string Observacion { get; set; }
        public decimal Valor { get; set; }

        [ForeignKey("ConductoresId")]
        public int ConductoresId { get; set; }
        public virtual Conductores Conductores { get; set; } 


    }
}
