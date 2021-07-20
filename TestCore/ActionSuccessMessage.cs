using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCore
{
    public class ActionSuccessMessage : IActionGeneralMessage
    {
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public object Data { get; set; }
    }
}
