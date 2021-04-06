using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA_Cukcuk_WebAPI.Extensions
{
    public class ValidateExceptions:Exception
    {
        public ValidateExceptions(string msg) : base(msg)
        {

        }

        public ValidateExceptions(string msg, string[] arrayMsg) : base(msg, new Exception())
        {

        }
    }
}
