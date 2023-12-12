using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambulance_API_CQRS.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message, object key) : base($"Entity {message}, {key} ")
        {

        }

    }
}
