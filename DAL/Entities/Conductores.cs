using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTransito.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Conductores
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int Id { get; set; }
        
        public string Identificacion { get; set; }
        public string Nombre { get; set; }        
        public string Apellido { get; set; }

        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public string Email { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public bool Activo { get; set; }


        [ForeignKey("MatriculasId")]
        public int  MatriculasId { get; set; }


        public virtual Matriculas Matriculas { get; set; }

        public virtual ICollection<Sanciones> Sanciones { get; set; }


    }
}
