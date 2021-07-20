using FluentValidationTest.Validations;
using System.Collections.Generic;

namespace FluentValidationTest.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Names { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<int> Friends { get; set; }
    }
}
