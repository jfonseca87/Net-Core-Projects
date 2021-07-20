using FluentValidationTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationTest.Validations
{
    public class PersonValidation: GeneralValidations<Person>
    // public class PersonValidation : ExntensionValidations
    {
        public PersonValidation() 
        {
            base.ApplyValidations(new ConfValidation { NombrePropiedad = "Names", NotEmpty = true, MinLength = 10, MaxLength = 100, ValidRegex = true, Regex = @"^([a-zA-Z])+$" });
            //base.ApplyValidations(x => x.Email, new ConfValidation { NotEmpty = true, MaxLength = 150, IsEmail = true });
            //base.ApplyValidations(x => x.Address, new ConfValidation { NotEmpty = true, MinLength = 0, MaxLength = 100, IsEmail = false });
            //base.ApplyValidations(x => x.PhoneNumber, new ConfValidation { NotEmpty = false, MinLength = 7, MaxLength = 10, IsEmail = false });
            //base.ApplyValidations(x => x.Friends, new ConfValidation { IsList = true });

            //base.SetNotEmptyRule(x => x.Names);
            //base.SetNotEmptyRule(x => x.Email);
            //base.SetNotEmptyRule(x => x.Address);
        }
    }
}
