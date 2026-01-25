using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Exceptions
{
    public class NotFoundException : Exception
    {

        public NotFoundException(string message) : base(message)
        {

        }
    }
}
