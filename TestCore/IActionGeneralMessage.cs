using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCore
{
    public interface IActionGeneralMessage
    {
        public int Status { get; set; }
        public DateTime Date { get; set; }
    }
}
