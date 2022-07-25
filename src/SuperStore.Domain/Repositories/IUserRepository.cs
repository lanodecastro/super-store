using SuperStore.Domain.Model;
using System;
using System.Collections.Generic;

namespace SuperStore.Domain.Repositories
{
    public interface IUserRepository
    {
        User Get(int userId);
        IList<User> All { get; }
    }
}
