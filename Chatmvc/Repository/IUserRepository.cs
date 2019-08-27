using Chatmvc.Models;
using System.Collections.Generic;

namespace Chatmvc.Repository
{
    public interface IUserRepository
    {
        void add(User user);

        List<User> get();

        List<User> getById(string nickName);
    }
}