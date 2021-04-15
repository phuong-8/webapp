﻿using RacoShop.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacoShop.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authenicate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);
    }
}