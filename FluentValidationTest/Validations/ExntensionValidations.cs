using FluentValidationTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace FluentValidationTest.Validations
{
    public class ExntensionValidations
    {
        public void CreateValidation<T>(string propertyName, string configuration)
        {
            Type typeClass = typeof(T);
            PropertyInfo property = typeClass.GetProperty(propertyName);
        }
    }
}
