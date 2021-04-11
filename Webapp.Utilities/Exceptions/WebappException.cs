using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapp.Utilities.Exceptions
{
    public class WebappException : Exception
    {
        public WebappException()
        {
        }
        public WebappException(string message):base(message)
        {
        }
        public WebappException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
