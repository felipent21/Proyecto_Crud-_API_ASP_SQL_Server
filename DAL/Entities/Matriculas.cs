using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTransito.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Matriculas
    {


       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id {get; set; }       
        public string Numero { get; set; }        
        public DateTime FechaExpedicion { get; set; }
        public DateTime ValidaHasta { get; set; }
        public bool Activo { get; set; }
        public virtual ICollection<Conductores> Conductores { get; set; }


    }
}
