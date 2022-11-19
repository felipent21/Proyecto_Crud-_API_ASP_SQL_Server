using ApiTransito.DAL.Entities;
using ApiTransito.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTransito.Utils
{
    public class ConductoresValidation : AbstractValidator<Conductores>
    {

        public ConductoresValidation()
        {

              RuleFor(s => s.Nombre)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty()
             .WithMessage("NOMBRE NO PUEDE ESTAR VACIO")
             .MaximumLength(10)
             .WithMessage("NOMBRE NO DEBE SUPERAR LAS 10 LETRAS");

             RuleFor(s => s.Apellido)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty()
             .WithMessage("APELLIDO NO PUEDE ESTAR VACIO")
             .MaximumLength(10)
             .WithMessage("APELLIDO NO DEBE SUPERAR LAS 10 LETRAS");

             RuleFor(s => s.Direccion).NotEmpty()
               .WithMessage("DIRECCION NO PUEDE ESTAR VACIA");

             RuleFor(s => s.Telefono)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty()
             .WithMessage("TELEFONO NO PUEDE ESTAR VACIO")
             .MaximumLength(10)
             .WithMessage("TELEFONO NO DEBE SUPERAR 10 DIGITOS");


             RuleFor(s => s.Email)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty()
             .WithMessage("EMAIL NO PUEDE ESTAR VACIO")
             .EmailAddress()
             .WithMessage("DEBE TENER FORMATO DE EMAIL");


             RuleFor(s => s.FechaNacimiento)
             .Must(Mayor)
             .WithMessage("DEBES SER MAYOR PARA REGISTRARSE");

             RuleFor(s => s.Activo).NotEmpty()
                .WithMessage("INGRESE SOLO FALSE O TRUE");
        }

        private  bool Mayor(DateTime fecha)
        {
            return DateTime.Now.AddYears(-18) >= fecha;
        }


    }
}
