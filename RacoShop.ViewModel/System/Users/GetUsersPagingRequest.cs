using RacoShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacoShop.ViewModel.System.Users
{
    public class GetUsersPagingRequest:PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
