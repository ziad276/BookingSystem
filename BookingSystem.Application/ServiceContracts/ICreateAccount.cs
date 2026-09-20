using BookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Application.Interfaces
{
    public interface ICreateAccount
    {
        Task<User> CreateUserAccountAsync(string name, string email, string password);
        Task<Provider> CreateProviderAccountAsync(int userId);

    }
}
