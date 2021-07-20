using FluentValidationTest.Models;
using FluentValidationTest.Validations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationTest.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreatePerson(Person person)
        {
            PersonValidation validation = new PersonValidation();
            var result = validation.Validate(person);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }
    }
}
