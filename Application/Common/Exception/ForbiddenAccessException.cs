using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exception
{
    public class ForbiddenAccessException : IOException
    {
        public ForbiddenAccessException() : base() { }
    }
}
