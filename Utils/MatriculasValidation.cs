using ApiTransito.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTransito.Utils
{
    public class MatriculasValidation: AbstractValidator<MatriculasDTO>
    {

        public MatriculasValidation() {

            DateTime dt = new DateTime(2022, 01, 01, 00, 00, 00);

            RuleFor(s => s.Numero)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .WithMessage("NUMERO NO PUEDE ESTAR VACIO")
            .MaximumLength(10)
            .WithMessage("NUMERO NO DEBE TENER LAS DE 10 DIGITOS");

            RuleFor(s => s.FechaExpedicion).NotEmpty().GreaterThan(dt)
                .WithMessage("EXPEDICIONES A PARTIR  DE 2022-01-01");

            RuleFor(s => s.ValidaHasta).NotEmpty().LessThan(s => s.FechaExpedicion.AddYears(10))
                .WithMessage("VIGENCIA MAXIMO 10 AÑOS");

            RuleFor(s => s.Activo).NotEmpty()
                .WithMessage("INGRESE SOLAMENTE false O true");

        }
    }
}
