using System;
using System.Linq;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/v1/person")]
    public class PersonController : ControllerBase
    {
        // private readonly PersonValidator personValidator;

        public PersonController()
        {
            // personValidator = new PersonValidator();
        }

        [HttpPost]
        [ValidatorUI]
        public IActionResult CreatePerson(Person person)
        {
            try
            {
                //var validateResult = personValidator.Validate(person);

                //if (!validateResult.IsValid) 
                //{
                //    return BadRequest(validateResult.Errors.Select(x => new { x.PropertyName, x.ErrorMessage }));
                //}

                Person newPerson = person;
                return Ok(newPerson);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
