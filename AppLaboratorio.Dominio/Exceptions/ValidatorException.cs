using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AppLaboratorio.Dominio.Exceptions
{
    public class ValidatorException:Exception
    {
        public ValidatorException(string message) : base(message)
        {

        }
    }
}
