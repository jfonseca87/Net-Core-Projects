using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using FluentValidationTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FluentValidationTest.Validations
{
    public abstract class GeneralValidations<T> : AbstractValidator<T> where T : class
    {
        public Expression<Func<T, object>> CreateValidation(string propertyName)
        {
            Type typeClass = typeof(T);
            PropertyInfo property = typeClass.GetProperty(propertyName);

            var clase = Expression.Parameter(typeof(T), "x");
            var propertyRef = Expression.Property(clase, property);
            var lambda = Expression.Lambda<Func<T, object>>(propertyRef, clase);
            return lambda;
            // RuleFor(lambda).SetValidator(new MinimumLengthValidator(10)).WithMessage("asdfasdsdfsdfsdfsdf");
        }

        public void ApplyValidations(ConfValidation conf)
        {
            Expression<Func<T, object>> expression = CreateValidation(conf.NombrePropiedad);

            if (conf.NotEmpty)
            {
                RuleFor(expression).NotEmpty().WithMessage("Este campo es obligatorio");
            }

            if (conf.MinLength > 0)
            {
                RuleFor(expression).SetValidator(new MinimumLengthValidator(conf.MinLength)).WithMessage($"Debe ser mayor de {conf.MinLength}");
            }

            if (conf.MaxLength > 0)
            {
                RuleFor(expression).SetValidator(new MaximumLengthValidator(conf.MaxLength)).WithMessage($"Debe ser mayor de {conf.MaxLength}");
            }

            if (conf.ValidRegex)
            {
                RuleFor(expression)
                    .Custom((texto, context) =>
                    {
                        if (!string.IsNullOrEmpty(texto.ToString()))
                        {
                            string value = texto.ToString();
                            var match = Regex.Match(value, conf.Regex);

                            if (!match.Success)
                            {
                                context.AddFailure("El campo no tiene un formato valido");
                            }
                        }
                    });
            }

            if (conf.IsEmail)
            {
                RuleFor(expression)
                    .Cascade(CascadeMode.Stop)
                    .NotNull().WithMessage("El mail no es valido")
                    .Custom((email, context) =>
                    {
                        string value = email.ToString();
                        var match = Regex.Match(value, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

                        if (!match.Success)
                        {
                            context.AddFailure("El mail no es valido");
                        }
                    });
            }

            if (conf.IsList)
            {
                RuleFor(expression)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El listado esta vacio")
                .Custom((list, context) =>
                {
                    dynamic listaInterna = list;
                    int cantidadItems = Enumerable.Count(listaInterna);

                    if (cantidadItems == 0)
                    {
                        context.AddFailure("El listado esta vacio");
                    }
                });
            }
        }



        //public void SetNotEmptyRule<TProperty>(Expression<Func<T, TProperty>> expression)
        //{
        //   RuleFor(expression).NotEmpty().WithMessage("asdasdasdasd");
        //}
    }
}
