using SuperStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperStore.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IList<User> _users;
        public UserRepository()
        {
            _users = new List<User>();
            _users.Add(new User(1,"João Santos", "joao.santos", "joao.santos@gmail.com"));
            _users.Add(new User(2,"Maria Souza", "maria.sousa", "maria.sousa@gmail.com"));

        }
        public IList<User> All => _users;

        public User Get(int userId)
        {
            return _users.FirstOrDefault(x => x.Id == userId);
        }
    }
}
