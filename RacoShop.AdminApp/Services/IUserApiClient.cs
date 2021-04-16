using RacoShop.ViewModel.Common;
using RacoShop.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RacoShop.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);

        Task<PagedResult<UserVm>> GetUsersPaging(GetUsersPagingRequest request);

        Task<bool> RegisterUser(RegisterRequest request);
    }
}
