using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacoShop.Utilities.Exceptions
{
    public class RacoShopException : Exception
    {
        public RacoShopException()
        {
        }
        public RacoShopException(string message):base(message)
        {
        }
        public RacoShopException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
