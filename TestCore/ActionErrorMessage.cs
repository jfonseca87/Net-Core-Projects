using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCore
{
    public class ActionErrorMessage : IActionGeneralMessage
    {
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public Guid TokenError { get; set; }
        public string ErrorMessage { get; set; }
        public object ErrorData { get; set; }
    }
}
