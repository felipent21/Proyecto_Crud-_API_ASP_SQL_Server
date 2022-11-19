using ApiTransito.DAL.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTransito.Utils
{
    public class SancionesValidation : AbstractValidator<Sanciones>
    {

        public SancionesValidation(){


            RuleFor(s => s.Sancion).NotEmpty()
               .WithMessage("DEBES LLENAR LA SANCION");

            RuleFor(s => s.Observacion).NotEmpty()
               .WithMessage("DEBES LLENAR LA OBSERVACION");

            RuleFor(s => s.Valor)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty()
             .WithMessage("NOMBRE NO PUEDE ESTAR VACIO")
             .LessThanOrEqualTo(500000)
             .WithMessage("EL VALOR  DE MULTA NO DEBE SUPERAR 500000");

        }

    }
}
